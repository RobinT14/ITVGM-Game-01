using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{   
    public Transform Player;

    //starting position
    public Vector3 PlayerPosition = new Vector3(-3.73f, -6.24f, 20.36f);
    // public Vector3 PlayerPosition = new Vector3(-12.44f, -11.25f, 15.35f);
    //show trigger objects
    public bool ShowTriggerobj1 = true;

    public static DontDestroy instance;
    void Start(){
        if (instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }

    
    public void SavePosition(){
        //slaat position op 
        PlayerPosition = Player.position;

        //Player.position = PlayerPosition;
        //PlayerPosition = new Vector3(-22.12f, -1.22f, 28.61f);
    }

    void Awake(){
        
        DontDestroyOnLoad(this.gameObject);
        
    }
}
