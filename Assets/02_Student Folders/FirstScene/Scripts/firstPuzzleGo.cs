using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPuzzleGo : MonoBehaviour
{
    public AudioSource source = null;
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    void start(){
        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
    }

    public void AudioStart()
    {
        source.Play(0);
    }

    public void OnFadeComplete()
    {
        if (dontdestroyinfo.ShowTriggerobj1)
        {
            //dontdestroyinfo.ShowTriggerobj1 = false;
            SceneManager.LoadScene("Puzzle1");
            Debug.Log("Succesfully loaded puzzle 1");
        }
    }
}
