using CampusTour.Network;
using NUnit.Framework;

namespace CampusTour.Tests
{
    public class ResponseParserTests
    {
        [Test]
        public void ParseImageList_UsesDeclaredCount()
        {
            ImageList list = ResponseParser.ParseImageList("2,a.jpg,b.jpg,c.jpg");

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("a.jpg", list.Paths[0]);
            Assert.AreEqual("b.jpg", list.Paths[1]);
        }

        [Test]
        public void ParseImageList_ClampsToAvailablePaths()
        {
            ImageList list = ResponseParser.ParseImageList("5,a.jpg");

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void ParseImageList_ReturnsEmptyForInvalidResponse()
        {
            Assert.AreEqual(0, ResponseParser.ParseImageList(null).Count);
            Assert.AreEqual(0, ResponseParser.ParseImageList("").Count);
            Assert.AreEqual(0, ResponseParser.ParseImageList("<html>error</html>").Count);
        }

        [Test]
        public void ParsePhotoZone_SplitsFieldsAndDescriptionLines()
        {
            PhotoZoneInfo info = ResponseParser.ParsePhotoZone("사자상@lion@추천인원 : 1 ~ 2명@첫째 줄#둘째 줄");

            Assert.AreEqual("사자상", info.Title);
            Assert.AreEqual("lion", info.ImageTag);
            Assert.AreEqual("추천인원 : 1 ~ 2명", info.Recommendation);
            Assert.AreEqual("첫째 줄\n둘째 줄\n", info.Description);
        }

        [Test]
        public void ParsePhotoZone_ReturnsNullWhenFieldsAreMissing()
        {
            Assert.IsNull(ResponseParser.ParsePhotoZone("사자상@lion"));
            Assert.IsNull(ResponseParser.ParsePhotoZone(null));
        }

        [Test]
        public void ParseMedia_MapsFieldsInServerOrder()
        {
            MediaInfo info = ResponseParser.ParseMedia("도깨비@설명1#설명2@goblin@tvN");

            Assert.AreEqual("도깨비", info.Title);
            Assert.AreEqual("설명1\n\n설명2\n\n", info.Description);
            Assert.AreEqual("goblin", info.ImageTag);
            Assert.AreEqual("tvN", info.Broadcaster);
        }

        [Test]
        public void ParseSearchResult_IgnoresEmptyLabels()
        {
            CollectionAssert.AreEqual(new[] { "도서관", "본관" }, ResponseParser.ParseSearchResult("도서관,,본관,"));
        }

        [Test]
        public void ParseSearchEntry_TreatsNullAsMissing()
        {
            SearchEntry entry = ResponseParser.ParseSearchEntry("학산도서관;6호관;null");

            Assert.AreEqual("학산도서관", entry.Name);
            Assert.AreEqual("6호관", entry.Location);
            Assert.IsFalse(entry.HasPhone);
            Assert.AreEqual("명칭 : 학산도서관\n위치 : 6호관", entry.ToDisplayText());
        }

        [Test]
        public void ParseSearchEntry_KeepsWholePhoneNumber()
        {
            // 전화번호는 길이와 형식에 상관없이 그대로 보존해야 한다.
            SearchEntry entry = ResponseParser.ParseSearchEntry("학생지원과;1호관;032-835-0000");

            Assert.AreEqual("032-835-0000", entry.Phone);
            Assert.AreEqual("명칭 : 학생지원과\n위치 : 1호관\n전화번호 : 032-835-0000", entry.ToDisplayText());
        }
    }
}
