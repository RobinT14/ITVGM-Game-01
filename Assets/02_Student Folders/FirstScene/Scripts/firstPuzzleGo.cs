using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPuzzleGo : MonoBehaviour
{
    // public GameObject reachpoint1 = null;
    //myObject.GetComponent<MyScript>().MyFunction();
    public AudioSource source = null;


    public void AudioStart()
    {
        //source = GetComponent<AudioSource>();
        source.Play(0);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Puzzle1");

        // reachpoint1.GetComponent<toFirstPuzzle>().OnFadeComplete();
        // Destroy(reachpoint1);
    }
}
