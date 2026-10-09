using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StampControl : MonoBehaviour
{
    public GameObject StampImage;

    // Use this for initialization
    void Start()
    {
        StampImage = GameObject.Find("Stamp");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Stamping()
    {
        float x = 0, y = 0;
        Vector2 StampScale = StampImage.GetComponent<Image>().rectTransform.localScale;
        while (x <= 1 && y <= 1)
        {
            x += 0.05f;
            y += 0.05f;
            StampImage.GetComponent<Image>().rectTransform.localScale = new Vector2(StampScale.x + x, StampScale.y + y);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(4.0f);

        while (x >= 0 && y >= 0)
        {
            x -= 0.05f;
            y -= 0.05f;
            StampImage.GetComponent<Image>().rectTransform.localScale = new Vector2(StampScale.x + x, StampScale.y + y);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public int exStamping()
    {
        StartCoroutine("Stamping");
        return 1;
    }
}
