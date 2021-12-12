using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPuzzle : MonoBehaviour
{

    public Image image;    
//    public GameObject object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     /*   if(Input.GetMouseButtonDown(0))
        {
         
        }*/
    }

    void OnMouseDown() 
    {
/*
     Color temp = image.color;
 temp.a=1f;
 image.color = temp; 
*/
StartCoroutine(FadeImage(true));
     
    }

IEnumerator FadeImage(bool fadeAway)
    {
        GameObject player = GameObject.Find("Player");

        // fade in
        if (fadeAway)
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                Color temp = image.color;
                temp.a=i;
                image.color = temp; 
                yield return null;
            }
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                Color temp = image.color;
                temp.a=i;
                image.color = temp; 
                player.transform.position = new Vector3(0,0,-8);
player.GetComponent<PlayerCharacterController>().gravityDownForce = 0f;

player.GetComponent<PlayerCharacterController>().maxSpeedOnGround = 0f;
player.GetComponent<PlayerCharacterController>().movementSharpnessOnGround = 0;
player.GetComponent<PlayerCharacterController>().maxSpeedCrouchedRatio = 0;
player.GetComponent<PlayerCharacterController>().maxSpeedInAir = 0;
player.GetComponent<PlayerCharacterController>().sprintSpeedModifier = 0;
player.GetComponent<PlayerCharacterController>().killHeight = 0;

                yield return null;
            }
        }
        // fade out
        else
        {

Debug.Log("else");
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                Color temp = image.color;
                temp.a=i;
                image.color = temp; 
                yield return null;
            }
        }
    }

}
