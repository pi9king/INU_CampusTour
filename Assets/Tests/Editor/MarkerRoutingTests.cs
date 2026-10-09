using CampusTour.Map;
using CampusTour.UI;
using NUnit.Framework;

namespace CampusTour.Tests
{
    public class MarkerRoutingTests
    {
        [TestCase(0.45f, MarkerCategory.Facility)]
        [TestCase(0.47f, MarkerCategory.Store)]
        [TestCase(0.48f, MarkerCategory.Cafeteria)]
        [TestCase(0.49f, MarkerCategory.Restaurant)]
        [TestCase(0.5f, MarkerCategory.PhotoZone)]
        [TestCase(0.6f, MarkerCategory.StarDramaScene)]
        [TestCase(0.65f, MarkerCategory.OtherDramaScene)]
        [TestCase(0.7f, MarkerCategory.SearchResult)]
        [TestCase(1f, MarkerCategory.None)]
        public void Resolve_MapsPrefabScaleToCategory(float scale, MarkerCategory expected)
        {
            Assert.AreEqual(expected, MarkerCategoryResolver.Resolve(scale));
        }

        [Test]
        public void Router_OpensDetailScreensOnlyForClickableCategories()
        {
            AssertScreen(MarkerCategory.PhotoZone, ScreenId.PhotoZone);
            AssertScreen(MarkerCategory.StarDramaScene, ScreenId.Media);
            AssertScreen(MarkerCategory.OtherDramaScene, ScreenId.Media);
            AssertScreen(MarkerCategory.Restaurant, ScreenId.Restaurant);
            AssertScreen(MarkerCategory.Cafeteria, ScreenId.MealMenu);

            ScreenId ignored;
            Assert.IsFalse(MarkerClickRouter.TryGetScreen(MarkerCategory.Facility, out ignored));
            Assert.IsFalse(MarkerClickRouter.TryGetScreen(MarkerCategory.Store, out ignored));
            Assert.IsFalse(MarkerClickRouter.TryGetScreen(MarkerCategory.SearchResult, out ignored));
            Assert.IsFalse(MarkerClickRouter.TryGetScreen(MarkerCategory.None, out ignored));
        }

        [Test]
        public void Registry_FindsScreenFromSceneNameIgnoringCase()
        {
            ScreenId id;
            Assert.IsTrue(ScreenRegistry.TryGetScreenId("two curri dept information(kor)", out id));
            Assert.AreEqual(ScreenId.DeptInfoTwoPages, id);
            Assert.IsFalse(ScreenRegistry.TryGetScreenId("60Min Tour", out id));
        }

        [TestCase(1, ScreenId.DeptInfo)]
        [TestCase(2, ScreenId.DeptInfoTwoPages)]
        [TestCase(3, ScreenId.DeptInfoThreePages)]
        [TestCase(4, ScreenId.DeptInfoFourPages)]
        public void Registry_PicksDeptScreenByCurriculumPages(int pages, ScreenId expected)
        {
            Assert.AreEqual(expected, ScreenRegistry.DeptInfoFor(pages));
        }

        private static void AssertScreen(MarkerCategory category, ScreenId expected)
        {
            ScreenId actual;
            Assert.IsTrue(MarkerClickRouter.TryGetScreen(category, out actual));
            Assert.AreEqual(expected, actual);
        }
    }
}
