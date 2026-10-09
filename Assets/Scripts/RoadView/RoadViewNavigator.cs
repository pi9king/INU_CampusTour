using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 360° 로드뷰 이동. 좌/우 버튼과 주요 장소 바로가기로 구체(Sphere) 사이를 이동하고, 터치 드래그로 시점을 돌린다.
/// </summary>
public class RoadViewNavigator : MonoBehaviour
{
    private const int CenterIndex = 68;
    private const int ConventionIndex = 55;
    private const int ClimbingIndex = 42;
    private const int EngineeringIndex = 30;
    private const float YawSpeed = 5f;
    private const float PitchSpeed = 2f;

    public GameObject loading;
    public Transform[] Sphere;

    private SphereChanger sphereChanger;
    private RoadViewControl roadViewControl;
    private Camera cam;
    private int index = CenterIndex;
    private float yaw;
    private float pitch;

    void Start()
    {
        cam = GetComponent<Camera>();
        GameObject tripod = GameObject.Find("Tripod");
        sphereChanger = tripod != null ? tripod.GetComponent<SphereChanger>() : null;
        GameObject manager = GameObject.Find("Manage");
        roadViewControl = manager != null ? manager.GetComponent<RoadViewControl>() : null;
        LoadSphereImage(index);
    }

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            yaw -= touch.deltaPosition.x * Time.deltaTime * YawSpeed;
            pitch += touch.deltaPosition.y * Time.deltaTime * PitchSpeed;
            cam.transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        }
    }

    public void LeftBtn()
    {
        MoveTo(index <= 0 ? CenterIndex : index - 1);
    }

    public void RightBtn()
    {
        MoveTo(index >= CenterIndex ? 0 : index + 1);
    }

    public void Centre()
    {
        MoveTo(CenterIndex);
    }

    public void CollEng()
    {
        MoveTo(EngineeringIndex);
    }

    public void Climbling()
    {
        MoveTo(ClimbingIndex);
    }

    public void Convention()
    {
        MoveTo(ConventionIndex);
    }

    public void GoMap()
    {
        SceneManager.LoadScene("GUItexture(Kor)");
    }

    private void MoveTo(int sphereIndex)
    {
        index = sphereIndex;
        LoadSphereImage(index);
        if (sphereChanger != null)
        {
            sphereChanger.ChangeSphere(Sphere[index]);
        }
    }

    private void LoadSphereImage(int sphereIndex)
    {
        if (roadViewControl == null)
        {
            return;
        }

        SetLoading(true);
        roadViewControl.LoadSphereTexture(Sphere[sphereIndex], ToImageNumber(sphereIndex), () => SetLoading(false));
    }

    // 서버 이미지 번호: 중앙(68)은 1번, 나머지는 인덱스 + 2
    private static int ToImageNumber(int sphereIndex)
    {
        return sphereIndex == CenterIndex ? 1 : sphereIndex + 2;
    }

    private void SetLoading(bool isLoading)
    {
        if (loading != null)
        {
            loading.SetActive(isLoading);
        }
    }
}
