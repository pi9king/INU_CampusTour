using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Korean : MonoBehaviour
{
    int check = 0;
    // Use this for initialization
    #region publiczone
    public void KoreanButton1()
    {
        Korean1();
    }
    public void EnglishButton()
    {
        English();
    }

    public void InuButton()
    {
        Inu();
    }

    public void DreamButton()
    {
        dream();
    }
    #endregion


    private void Start()
    {
        Screen.SetResolution(480, 800, true);
        check=PlayerPrefs.GetInt("Check");
        if (check == 0)
        { }
        else if(check==1)
        {
            SceneManager.LoadScene("GUItexture(Kor)");
        }
        else if(check==2)
        {
            SceneManager.LoadScene("GUItexture(Kor)");
        }
    }

    #region realzone
    void start1()
    {
        SceneManager.LoadScene(3);

    }
    void Korean1()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("Check", 2);
    }
    void English()
    {
        SceneManager.LoadScene("Start(English)");
        PlayerPrefs.SetInt("Check", 1);
    }
    void Inu()
    {
        Application.OpenURL("http://www.inu.ac.kr");
    }

    void dream()
    {
        Application.OpenURL("https://blog.naver.com/dream_we");
    }
    #endregion
}