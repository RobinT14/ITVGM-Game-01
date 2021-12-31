using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPuzzleGo : MonoBehaviour
{
    // public GameObject reachpoint1 = null;
    //myObject.GetComponent<MyScript>().MyFunction();
    public AudioSource source = null;
     GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    void start(){
        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
    }

    public void AudioStart()
    {
        //source = GetComponent<AudioSource>();
        source.Play(0);
    }

    public void OnFadeComplete()
    {
        if (dontdestroyinfo.ShowTriggerobj1)
        {
            dontdestroyinfo.ShowTriggerobj1 = false;
            SceneManager.LoadScene("Puzzle1");
            Debug.Log("Succesfully loaded puzzle 1");
        }
        // reachpoint1.GetComponent<toFirstPuzzle>().OnFadeComplete();
        // Destroy(reachpoint1);

        Debug.Log("after if");
    }
}
