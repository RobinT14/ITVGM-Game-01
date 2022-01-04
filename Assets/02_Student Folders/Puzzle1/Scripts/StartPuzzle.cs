using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPuzzle : MonoBehaviour
{
    public Collider trigger;
    public Image image;    

    void OnTriggerEnter(Collider trigger)
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        GameObject player = GameObject.Find("Player");

        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            Color changingColor = image.color;
            changingColor.a=i;
            image.color = changingColor; 
            yield return null;
        }
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            Color changingColor = image.color;
            changingColor.a=i;
            image.color = changingColor; 
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
}
