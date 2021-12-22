using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toFirstPuzzle : MonoBehaviour
{
    private bool startgame = true;
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    void start(){
        
    }

    void Update(){
        if(startgame)
        {
            PositionPlayer = GameObject.Find("PlayerPosition");
            dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
            startgame = false;
        }

        if(!dontdestroyinfo.ShowTriggerobj1)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {   
        
        if (dontdestroyinfo.ShowTriggerobj1){
        // Debug.Log("switch!");
            dontdestroyinfo.ShowTriggerobj1 = false;
            dontdestroyinfo.SavePosition();
            SceneManager.LoadScene("Puzzle1");
        }
    }
}
