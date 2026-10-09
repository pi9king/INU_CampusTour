using System;
using System.Collections.Generic;
using CampusTour.Core;
using UnityEngine;

namespace CampusTour.Network
{
    /// <summary>
    /// 원격 이미지를 Sprite로 받아 캐시하고, 화면(scope) 단위로 해제한다.
    /// </summary>
    public class ImageLoader : Singleton<ImageLoader>
    {
        private const string FallbackSpritePath = "Loading/파일로딩 실패 이미지";

        private class Entry
        {
            public Sprite Sprite;
            public readonly HashSet<string> Scopes = new HashSet<string>();
        }

        private class PendingRequest
        {
            public readonly List<KeyValuePair<string, Action<Sprite>>> Callbacks = new List<KeyValuePair<string, Action<Sprite>>>();
        }

        private readonly Dictionary<string, Entry> cache = new Dictionary<string, Entry>();
        private readonly Dictionary<string, PendingRequest> pending = new Dictionary<string, PendingRequest>();
        private Sprite fallbackSprite;

        public int CachedCount
        {
            get { return cache.Count; }
        }

        public Sprite FallbackSprite
        {
            get
            {
                if (fallbackSprite == null)
                {
                    fallbackSprite = Resources.Load<Sprite>(FallbackSpritePath);
                }
                return fallbackSprite;
            }
        }

        /// <summary>
        /// url의 이미지를 불러온다. 실패하면 대체 이미지를 전달한다.
        /// scope를 해제하면 아직 도착하지 않은 콜백도 호출되지 않는다.
        /// </summary>
        public void Load(string url, string scope, Action<Sprite> onLoaded)
        {
            Entry entry;
            if (cache.TryGetValue(url, out entry))
            {
                entry.Scopes.Add(scope);
                if (onLoaded != null)
                {
                    onLoaded(entry.Sprite);
                }
                return;
            }

            PendingRequest request;
            bool alreadyRequested = pending.TryGetValue(url, out request);
            if (!alreadyRequested)
            {
                request = new PendingRequest();
                pending.Add(url, request);
            }
            request.Callbacks.Add(new KeyValuePair<string, Action<Sprite>>(scope, onLoaded));

            if (!alreadyRequested)
            {
                ApiClient.Instance.GetTexture(url, delegate(ApiResult<Texture2D> result) { OnTextureLoaded(url, result); });
            }
        }

        /// <summary>
        /// 해당 화면에서 사용한 이미지를 해제한다. 다른 화면에서도 쓰는 이미지는 유지된다.
        /// </summary>
        public void ReleaseScope(string scope)
        {
            foreach (PendingRequest request in pending.Values)
            {
                request.Callbacks.RemoveAll(delegate(KeyValuePair<string, Action<Sprite>> callback) { return callback.Key == scope; });
            }

            List<string> unused = new List<string>();
            foreach (KeyValuePair<string, Entry> pair in cache)
            {
                pair.Value.Scopes.Remove(scope);
                if (pair.Value.Scopes.Count == 0)
                {
                    unused.Add(pair.Key);
                }
            }
            for (int i = 0; i < unused.Count; i++)
            {
                DestroySprite(cache[unused[i]].Sprite);
                cache.Remove(unused[i]);
            }
        }

        private void OnTextureLoaded(string url, ApiResult<Texture2D> result)
        {
            PendingRequest request = pending[url];
            pending.Remove(url);

            if (!result.Success)
            {
                InvokeCallbacks(request, FallbackSprite);
                return;
            }

            Texture2D texture = result.Data;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            if (request.Callbacks.Count == 0)
            {
                // 요청한 화면이 이미 닫혔다.
                DestroySprite(sprite);
                return;
            }

            Entry entry = new Entry();
            entry.Sprite = sprite;
            for (int i = 0; i < request.Callbacks.Count; i++)
            {
                entry.Scopes.Add(request.Callbacks[i].Key);
            }
            cache.Add(url, entry);
            InvokeCallbacks(request, sprite);
        }

        private static void InvokeCallbacks(PendingRequest request, Sprite sprite)
        {
            for (int i = 0; i < request.Callbacks.Count; i++)
            {
                Action<Sprite> callback = request.Callbacks[i].Value;
                if (callback != null)
                {
                    callback(sprite);
                }
            }
        }

        private static void DestroySprite(Sprite sprite)
        {
            if (sprite == null)
            {
                return;
            }
            Destroy(sprite.texture);
            Destroy(sprite);
        }
    }
}
