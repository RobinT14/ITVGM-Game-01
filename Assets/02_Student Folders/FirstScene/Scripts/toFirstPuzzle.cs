using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toFirstPuzzle : MonoBehaviour
{
    private bool startgame = true;
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;
    public Animator animator;
    // public string levelToLoad = null;
    public string chosenAnimation = null;

    void Start()
    {

    }

    void Update()
    {
        if (startgame)
        {
            PositionPlayer = GameObject.Find("PlayerPosition");
            dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
            startgame = false;
        }

        if (!dontdestroyinfo.ShowTriggerobj1)
        {

            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (dontdestroyinfo.ShowTriggerobj1)
        {
            // Debug.Log("switch!");
            dontdestroyinfo.ShowTriggerobj1 = false;
            dontdestroyinfo.SavePosition();
            FadeToLevel(); //levelToLoad
        }
    }

    public void FadeToLevel() // string levelName
    {
        // levelToLoad = levelName;
        animator.SetTrigger(chosenAnimation);
        //OnFadeComplete();
    }

    //public void OnFadeComplete()
    //{
    //    SceneManager.LoadScene(levelToLoad);
    //}
}
