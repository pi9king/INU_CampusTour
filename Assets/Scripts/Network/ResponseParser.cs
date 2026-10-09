using System;
using System.Collections.Generic;
using System.Text;

namespace CampusTour.Network
{
    /// <summary>"개수,경로1,경로2,..." 형식의 이미지 목록</summary>
    public class ImageList
    {
        public readonly List<string> Paths = new List<string>();

        public int Count
        {
            get { return Paths.Count; }
        }
    }

    /// <summary>포토존 정보: "제목@이미지태그@추천인원@설명1#설명2..."</summary>
    public class PhotoZoneInfo
    {
        public string Title;
        public string ImageTag;
        public string Recommendation;
        public string Description;
    }

    /// <summary>미디어(드라마) 정보: "제목@설명1#설명2...@이미지태그@방송사"</summary>
    public class MediaInfo
    {
        public string Title;
        public string Description;
        public string ImageTag;
        public string Broadcaster;
    }

    /// <summary>검색 상세 정보: "명칭;위치;전화번호" (값이 없으면 "null")</summary>
    public class SearchEntry
    {
        public string Name;
        public string Location;
        public string Phone;

        public bool HasPhone
        {
            get { return !string.IsNullOrEmpty(Phone); }
        }

        public string ToDisplayText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("명칭 : ").Append(Name);
            if (!string.IsNullOrEmpty(Location))
            {
                builder.Append("\n위치 : ").Append(Location);
            }
            if (HasPhone)
            {
                builder.Append("\n전화번호 : ").Append(Phone);
            }
            return builder.ToString();
        }
    }

    /// <summary>
    /// 서버 응답 문자열 파싱. 응답 형식이 어긋나도 예외 대신 null 또는 빈 결과를 반환한다.
    /// </summary>
    public static class ResponseParser
    {
        private const char FieldSeparator = '@';
        private const char LineSeparator = '#';
        private const char ListSeparator = ',';
        private const char SearchSeparator = ';';
        private const string NullValue = "null";

        public static ImageList ParseImageList(string raw)
        {
            ImageList list = new ImageList();
            if (string.IsNullOrEmpty(raw))
            {
                return list;
            }

            string[] tokens = raw.Split(ListSeparator);
            int declaredCount;
            if (!int.TryParse(tokens[0].Trim(), out declaredCount))
            {
                return list;
            }

            int count = Math.Min(declaredCount, tokens.Length - 1);
            for (int i = 1; i <= count; i++)
            {
                string path = tokens[i].Trim();
                if (path.Length > 0)
                {
                    list.Paths.Add(path);
                }
            }
            return list;
        }

        public static PhotoZoneInfo ParsePhotoZone(string raw)
        {
            string[] fields = SplitFields(raw, 4);
            if (fields == null)
            {
                return null;
            }

            PhotoZoneInfo info = new PhotoZoneInfo();
            info.Title = fields[0];
            info.ImageTag = fields[1];
            info.Recommendation = fields[2];
            info.Description = JoinLines(fields[3], "\n");
            return info;
        }

        public static MediaInfo ParseMedia(string raw)
        {
            string[] fields = SplitFields(raw, 4);
            if (fields == null)
            {
                return null;
            }

            MediaInfo info = new MediaInfo();
            info.Title = fields[0];
            info.Description = JoinLines(fields[1], "\n\n");
            info.ImageTag = fields[2];
            info.Broadcaster = fields[3];
            return info;
        }

        public static List<string> ParseSearchResult(string raw)
        {
            List<string> labels = new List<string>();
            if (string.IsNullOrEmpty(raw))
            {
                return labels;
            }

            string[] tokens = raw.Split(ListSeparator);
            for (int i = 0; i < tokens.Length; i++)
            {
                string label = tokens[i].Trim();
                if (label.Length > 0)
                {
                    labels.Add(label);
                }
            }
            return labels;
        }

        public static SearchEntry ParseSearchEntry(string raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return null;
            }

            string[] tokens = raw.Split(SearchSeparator);
            SearchEntry entry = new SearchEntry();
            entry.Name = tokens[0].Trim();
            entry.Location = tokens.Length > 1 ? NullToEmpty(tokens[1]) : string.Empty;
            entry.Phone = tokens.Length > 2 ? NullToEmpty(tokens[2]) : string.Empty;
            return entry;
        }

        private static string[] SplitFields(string raw, int expectedCount)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return null;
            }

            string[] fields = raw.Split(FieldSeparator);
            return fields.Length < expectedCount ? null : fields;
        }

        private static string JoinLines(string field, string lineEnding)
        {
            string[] lines = field.Split(LineSeparator);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                builder.Append(lines[i]).Append(lineEnding);
            }
            return builder.ToString();
        }

        private static string NullToEmpty(string value)
        {
            string trimmed = value.Trim();
            return trimmed == NullValue ? string.Empty : trimmed;
        }
    }
}
