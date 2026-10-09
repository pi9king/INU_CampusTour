using System.Collections;
using System.Collections.Generic;
using CampusTour.Network;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 키워드 검색. 서버가 돌려준 마커 이름들을 지도에서 찾아 강조하고, 연락처 목록을 만든다.
/// </summary>
public class MarkerSearch : MonoBehaviour
{
    private const int MinKeywordLength = 2;

    public InputField Keyword;
    public GameObject Cancel;
    public GameObject Popup;
    public GameObject Call;

    private readonly List<SearchEntry> results = new List<SearchEntry>();

    /// <summary>마지막 검색에서 찾은 장소들. 연락처 화면에 전달된다.</summary>
    public IList<SearchEntry> Results
    {
        get { return results.AsReadOnly(); }
    }

    void Start()
    {
        Instantiate(Popup);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Search_Info();
        }
    }

    public void Search_Info()
    {
        results.Clear();
        StopAllCoroutines();
        StartCoroutine(Search(Keyword.text));
        Cancel.SetActive(true);
    }

    public void OffPopup()
    {
        Popup.SetActive(false);
    }

    private IEnumerator Search(string keyword)
    {
        if (string.IsNullOrEmpty(keyword) || keyword.Length < MinKeywordLength)
        {
            Popup.SetActive(true);
            yield break;
        }

        ApiResult<string> searchResponse = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.Search(keyword), result => searchResponse = result);
        List<string> labels = searchResponse.Success ? ResponseParser.ParseSearchResult(searchResponse.Data) : new List<string>();

        OnlineMaps map = NewBtnManage.GetMapsInstance().GetComponent<OnlineMaps>();
        map.OffMarkers();
        if (labels.Count == 0)
        {
            Popup.SetActive(true);
            yield break;
        }

        HashSet<string> markerLabels = new HashSet<string>(map.GetMarkersLabel().Split(','));
        Vector2 lastPosition = Vector2.zero;
        int foundCount = 0;
        for (int i = 0; i < labels.Count; i++)
        {
            string label = labels[i];
            if (!markerLabels.Contains(label))
            {
                Popup.SetActive(true);
                break;
            }

            ApiResult<string> detailResponse = null;
            yield return ApiClient.Instance.GetText(ApiEndpoints.SearchDetail(label), result => detailResponse = result);
            SearchEntry entry = detailResponse.Success ? ResponseParser.ParseSearchEntry(detailResponse.Data) : null;
            if (entry == null)
            {
                entry = new SearchEntry();
                entry.Name = label;
            }

            lastPosition = map.ActSelMarker(label, entry.ToDisplayText());
            results.Add(entry);
            foundCount++;
        }

        if (foundCount == 1)
        {
            map.ChangePosition(lastPosition);
        }
        else
        {
            map.SetHome();
        }

        if (foundCount > 0)
        {
            Call.SetActive(true);
        }
    }
}
