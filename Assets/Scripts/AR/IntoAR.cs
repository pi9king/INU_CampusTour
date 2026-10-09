using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoAR : MonoBehaviour {

    //사용자위치
    [SerializeField] private GameObject PopUp;          //60분 인트로 팝업창
    [SerializeField] private GameObject PopUp30;
    [SerializeField] private GameObject PopUpdrama;
    [SerializeField] private GameObject PopUpliberal;
    [SerializeField] private GameObject PopUpscience;
    public GameObject menu;
    Vector2 PlayerLocation;
    bool dramac = false;

    void Update () {
        PlayerLocation.x = Input.location.lastData.latitude;
        PlayerLocation.y = Input.location.lastData.longitude;
	}

    public void AROn()
    {
        SceneManager.LoadScene("UFO");
    }

   
#region 60분코스
    public void AR60PopupStart()
    {
        PopUp.SetActive(true);
        menu.SetActive(false);
    }

    public void AR30PopupStart()
    {
        PopUp30.SetActive(true);
        menu.SetActive(false);
    }

    public void ARDramaPopupStart()
    {
        PopUpdrama.SetActive(true);
        menu.SetActive(false);
    }

    public void ARLiberalPopupStart()
    {
        PopUpliberal.SetActive(true);
        menu.SetActive(false);
    }

    public void ARSciencePopupStart()
    {
        PopUpscience.SetActive(true);
        menu.SetActive(false);
    }

    public void ARPopupOff()
    {
        PopUp.SetActive(false);
    }

    public void AR30PopupOff()
    {
        PopUp30.SetActive(false);
    }

    public void ARdramaPopupOff()
    {
        PopUpdrama.SetActive(false);
    }

    public void ARliberalPopupOff()
    {
        PopUpliberal.SetActive(false);
    }

    public void ARsciencePopupOff()
    {
        PopUpscience.SetActive(false);
    }


    public void INUDroneClick()
    {
        Application.OpenURL("https://www.facebook.com/INUdreamwe/videos/1930508923853500/");
    }
    #endregion
}
