using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour, IPointerClickHandler {

    public InputField SearchField;
	// Use this for initialization
	void Start () {
        SearchField = gameObject.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        SearchField.text = "";
    }
}
