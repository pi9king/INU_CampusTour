using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour {
    [SerializeField] private GameObject[] z;
    // Use this for initialization
    void Start () {
        StartCoroutine("SizeUp",0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SizeUp(int k)
    {
        int temp = k+1;
        GameObject a1;
        a1 = z[k];
        int i = 0;
        float y = 0;
        Vector2 Scale = a1.GetComponent<Image>().rectTransform.localScale;
        while (i<50)
        {
            i++;
            y += 0.05f;
            a1.GetComponent<Image>().rectTransform.localScale = new Vector2(Scale.x,y);
            yield return new WaitForSeconds(0.01f);
        }

        if (k < 3) { StartCoroutine("SizeUp", temp++); } else { }
    }

}
