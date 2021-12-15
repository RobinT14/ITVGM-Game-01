using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  
using TMPro;

public class TextColorChanger : MonoBehaviour
{
//     public Text theText;
 private TMP_Text m_TextComponent;
/*
	private Color basicColor = Color.green;
	private Color hoverColor = Color.red;
	private Renderer renderer;
 
	void Start() {
		renderer = GetComponent<Renderer>();
		renderer.material.color = basicColor;
	}
 
	void OnMouseEnter() {
		renderer.material.color = hoverColor;
	}
 
	void OnMouseExit() {
		renderer.material.color = basicColor;
	}
*/

/*
    // Test for enter and exit:
    public void OnPointerEnter(PointerEventData eventData) {
          GetComponent<Text>().color = Color.gray; // Changes the colour of the text
    }
 
    public void OnPointerExit(PointerEventData eventData) {
          GetComponent<Text>().color = Color.black; // Changes the colour of the text
    }
*/
/*
     public void OnPointerEnter(PointerEventData eventData)
     {
m_TextComponent = GetComponent<TMP_Text>();
         m_TextComponent.color = Color.red; //Or however you do your color
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         theText.color = Color.white; //Or however you do your color
     }
*/
}
