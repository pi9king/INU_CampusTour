using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPop : MonoBehaviour {

    public void EndYes()
    {
        Application.Quit();
    }

    public void EndNo()
    {
        this.gameObject.SetActive(false);
    }
}
