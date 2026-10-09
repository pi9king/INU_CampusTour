using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBtnManage : MonoBehaviour {
    private static GameObject mapobj;
    private static bool made = false;
	// Use this for initialization
	void Start () {
        mapobj = this.gameObject;
        DontDestroyOnLoad(this);
        mapobj.SendMessage("SetClear");
	}

    #region 실행부

    public static GameObject GetMapsInstance()
    {
        return mapobj;
    }


    public static void Photo()
    {
        PhotoZoneC();
    }

    public static void Drama(string DN)
    {
        DramaC(DN);
    }

    public static void Restaurant()
    {
        RestaurantC();
    }

    public static void DestRoll()
    {
        Destroy(mapobj);
    }

    public static void EtcDrama()
    {
        EtcDramac();
    }

    public static void GoToUniv()
    {
        GoToUnivC();
    }

    public static void GoToMe()
    {
        GoToMeC();
    }
    #endregion

    #region 선언부
    //포토존 마커 키는 함수
    private static void PhotoZoneC()
    {
        mapobj.SendMessage("SetPhoto");
    }
    //드라마(별에서온그대) 마커 키는 함수
    private static void DramaC(string dramaname)
    {
        mapobj.SendMessage("SetDrama", dramaname);
    }
    //드라마(기타) 마커 키는 함수
    private static void EtcDramac()
    {
        mapobj.SendMessage("SetetcDrama");
    }
    //레스토랑 마커 키는 함수
    private static void RestaurantC()
    {
        mapobj.SendMessage("SetRestaurant");
    }
    //학교로 돌아가기
    private static void GoToUnivC()
    {
        mapobj.SendMessage("SetHome");
    }
    //내 위치로 돌아가기
    private static void GoToMeC()
    {
        mapobj.SendMessage("SetMe");
    }
    #endregion
}
