using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class POPUP : MonoBehaviour {
    public GameObject sure;
    public GameObject no;
    public GameObject cam;


    public void Exit()
    {
        sure.SetActive(false);
    }

    public void GoAR()
    {
        SceneManager.LoadScene("UFO");
    }
}
