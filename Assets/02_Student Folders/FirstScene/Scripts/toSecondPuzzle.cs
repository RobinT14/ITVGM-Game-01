using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toSecondPuzzle : MonoBehaviour
{
    // transportation location
    private bool startgame = true;
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    // animation variables
    public Animator animator;
    // public string levelToLoad = null;
    public string chosenAnimation = null;

    void Start(){}

    void Update(){
        if(startgame)
        {
            PositionPlayer = GameObject.Find("PlayerPosition");
            dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
            startgame = false;
        }

        if(!dontdestroyinfo.ShowTriggerobj2)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {   
        
        if (dontdestroyinfo.ShowTriggerobj2)
        {
            dontdestroyinfo.ShowTriggerobj2 = false;
            dontdestroyinfo.SavePosition();
            FadeToLevel(); //levelToLoad
        }
    }

    public void FadeToLevel() // string levelName
    {
        // levelToLoad = levelName;
        animator.SetTrigger(chosenAnimation);
        Debug.Log("Activated animation!");
        // OnFadeComplete();
    }

    //public void OnFadeComplete()
    //{
    //    SceneManager.LoadScene(levelToLoad);
    //}

}
