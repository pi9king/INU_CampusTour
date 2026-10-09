using CampusTour.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CampusTour.Tour
{
    /// <summary>
    /// 투어 씬의 진입점. 코스 데이터(TourDefinition)로 지도와 상태 머신을 준비하고, 상태가 요청한 엔진 기능을 수행한다.
    /// 5개 코스가 모두 이 컴포넌트 하나를 쓴다.
    /// </summary>
    [RequireComponent(typeof(TourView))]
    public class TourController : MonoBehaviour, ITourHost
    {
        [SerializeField] private TourDefinition definition;

        private TourContext context;

        public TourStateId CurrentState
        {
            get { return context == null ? TourStateId.None : context.StateMachine.CurrentId; }
        }

        private void Start()
        {
            TourView view = GetComponent<TourView>();

            if (TourSession.IsReturningFromAr(definition))
            {
                TourSession.ReturnFromAr();
                context = new TourContext(TourSession.Progress, TourSession.Map, view, this);
                context.ChangeState(TourStateId.ShowingInfo);
                return;
            }

            GameObject mapObject = Instantiate(definition.mapPrefab);
            ITourMap map = mapObject.GetComponent<OnlineMapsTourMap>();
            TourProgress progress = new TourProgress(definition.route);
            TourSession.Begin(definition, progress, map);

            context = new TourContext(progress, map, view, this);
            context.ChangeState(TourStateId.Preparing);
        }

        private void Update()
        {
            if (context != null)
            {
                context.StateMachine.Tick(Time.deltaTime);
            }
        }

        public void Vibrate()
        {
            Handheld.Vibrate();
        }

        public void OpenArScene()
        {
            TourSession.EnterAr();
            SceneManager.LoadScene(ScreenRegistry.ArSceneName);
        }

        public void CompleteTour()
        {
            StampBook.Collect(definition.stampKey);
        }

        public void ExitTour()
        {
            TourSession.End();
            SceneManager.LoadScene(ScreenRegistry.MainSceneName);
        }
    }
}
