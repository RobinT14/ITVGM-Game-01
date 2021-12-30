using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPuzzleGo : MonoBehaviour
{
    // public GameObject reachpoint1 = null;
    //myObject.GetComponent<MyScript>().MyFunction();

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Puzzle1");

        // reachpoint1.GetComponent<toFirstPuzzle>().OnFadeComplete();
        // Destroy(reachpoint1);
    }
}
