using System;

namespace CampusTour.Network
{
    /// <summary>
    /// 서버 주소는 이 클래스에서만 관리한다.
    /// </summary>
    public static class ApiEndpoints
    {
        public const string Host = "http://ec2-13-125-92-177.ap-northeast-2.compute.amazonaws.com/";
        public const string ImageRoot = Host + "image/";

        private const string RoadViewImagePrefix = ImageRoot + "roadview/roadview";
        private const string SchoolMealRoot = "http://www.inu.ac.kr/com/cop/mainWork/";

        public static string Search(string keyword)
        {
            return Host + "search.php?keyword=" + Escape(keyword);
        }

        public static string SearchDetail(string markerLabel)
        {
            return Host + "searchdata.php?keyword=" + Escape(markerLabel);
        }

        public static string PhotoZoneInfo(string titleLabel)
        {
            return Host + "photozone_findtag.php?titlelabel=" + Escape(titleLabel);
        }

        public static string MediaInfo(string titleLabel)
        {
            return Host + "drama_findtag.php?titlelabel=" + Escape(titleLabel);
        }

        public static string RestaurantInfo(string restaurantTag)
        {
            return Host + "unity.php?titlelabel=" + Escape(restaurantTag);
        }

        public static string ImageList(string imageTag)
        {
            return Host + "image_list.php?imagetag=" + Escape(imageTag);
        }

        public static string Image(string relativePath)
        {
            return ImageRoot + relativePath;
        }

        /// <summary>드라마 투어 갤러리 이미지. 서버에 일부 파일만 png로 올라가 있다.</summary>
        public static string DramaSceneImage(string imageName)
        {
            bool isPng = imageName == "whoareyou1" || imageName == "oneyeartwelveman" ||
                         imageName == "lovetemper4" || imageName.Contains("manipulation");
            if (isPng)
            {
                return ImageRoot + "drama/" + imageName + ".png";
            }
            if (imageName.Contains("star"))
            {
                return ImageRoot + "star/" + imageName + ".jpg";
            }
            return ImageRoot + "drama/" + imageName + ".jpg";
        }

        public static string RoadViewImage(int index)
        {
            return RoadViewImagePrefix + index + ".jpg";
        }

        public static string SchoolMeal(string page)
        {
            return SchoolMealRoot + page;
        }

        private static string Escape(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : Uri.EscapeDataString(value);
        }
    }
}
