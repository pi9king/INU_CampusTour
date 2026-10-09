using System;
using System.Collections;
using System.Text;
using CampusTour.Core;
using UnityEngine;
using UnityEngine.Networking;

namespace CampusTour.Network
{
    /// <summary>
    /// 모든 HTTP 요청의 진입점(Facade).
    /// 타임아웃, 재시도, 오류 분류, 응답 인코딩 처리를 한 곳에서 담당한다.
    /// </summary>
    public class ApiClient : Singleton<ApiClient>
    {
        [SerializeField] private int timeoutSeconds = 20;
        [SerializeField] private int maxRetryCount = 3;

        public Coroutine GetText(string url, Action<ApiResult<string>> onDone)
        {
            return StartCoroutine(SendWithRetry(
                delegate { return UnityWebRequest.Get(url); },
                ReadText,
                onDone));
        }

        public Coroutine GetTexture(string url, Action<ApiResult<Texture2D>> onDone)
        {
            return StartCoroutine(SendWithRetry(
                delegate { return UnityWebRequestTexture.GetTexture(url); },
                DownloadHandlerTexture.GetContent,
                onDone));
        }

        private IEnumerator SendWithRetry<T>(
            Func<UnityWebRequest> createRequest,
            Func<UnityWebRequest, T> readResponse,
            Action<ApiResult<T>> onDone)
        {
            ApiResult<T> result = null;
            for (int attempt = 0; attempt <= maxRetryCount; attempt++)
            {
                using (UnityWebRequest request = createRequest())
                {
                    request.timeout = timeoutSeconds;
                    yield return request.SendWebRequest();
                    result = ToResult(request, readResponse);
                }

                if (result.Success || !IsRetryable(result.Error))
                {
                    break;
                }
                Debug.LogWarning("[ApiClient] 요청 실패, 재시도 " + (attempt + 1) + "/" + maxRetryCount + " : " + result.Message);
            }

            if (!result.Success)
            {
                Debug.LogError("[ApiClient] 요청 최종 실패 (" + result.Error + ") : " + result.Message);
            }
            if (onDone != null)
            {
                onDone(result);
            }
        }

        private static ApiResult<T> ToResult<T>(UnityWebRequest request, Func<UnityWebRequest, T> readResponse)
        {
            if (request.isNetworkError)
            {
                bool isTimeout = request.error != null && request.error.IndexOf("timeout", StringComparison.OrdinalIgnoreCase) >= 0;
                return ApiResult<T>.Fail(isTimeout ? ApiError.Timeout : ApiError.Network, request.url + " : " + request.error);
            }
            if (request.isHttpError)
            {
                return ApiResult<T>.Fail(ApiError.Http, request.url + " : HTTP " + request.responseCode);
            }

            try
            {
                return ApiResult<T>.Ok(readResponse(request));
            }
            catch (Exception e)
            {
                return ApiResult<T>.Fail(ApiError.Network, request.url + " : " + e.Message);
            }
        }

        private static bool IsRetryable(ApiError error)
        {
            return error == ApiError.Network || error == ApiError.Timeout;
        }

        /// <summary>
        /// Content-Type의 charset을 따른다. (학교 홈페이지가 UTF-8이 아닐 수 있다)
        /// </summary>
        private static string ReadText(UnityWebRequest request)
        {
            byte[] data = request.downloadHandler.data;
            if (data == null)
            {
                return string.Empty;
            }
            return GetEncoding(request.GetResponseHeader("Content-Type")).GetString(data).Trim();
        }

        private static Encoding GetEncoding(string contentType)
        {
            const string charsetKey = "charset=";
            if (!string.IsNullOrEmpty(contentType))
            {
                int index = contentType.IndexOf(charsetKey, StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    string charset = contentType.Substring(index + charsetKey.Length).Trim().Trim('"', ';');
                    try
                    {
                        return Encoding.GetEncoding(charset);
                    }
                    catch (ArgumentException)
                    {
                        Debug.LogWarning("[ApiClient] 지원하지 않는 charset : " + charset);
                    }
                }
            }
            return Encoding.UTF8;
        }
    }
}
