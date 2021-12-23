using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public Transform Player;

    private Vector3 positionVector;
    public DontDestroy SavedPosition;
    GameObject PositionPlayer;

    public GameObject FloorKey;
    void Start()
    {
        PositionPlayer = GameObject.Find("PlayerPosition");
        SavedPosition = PositionPlayer.GetComponent<DontDestroy>();
        //Debug.Log("GetComponent is gedaan");

        //player wordt verplaatst naar de plek dat gesaved is
        //alleen als puzzle 1 is opgelost
        if (!SavedPosition.ShowTriggerobj1){
            positionVector = SavedPosition.PlayerPosition - new Vector3 (0,0,1);
            Player.position = positionVector;
            FloorKey.SetActive(true);
            
        }
        //Player.position = new Vector3(-22.12f, -1.22f, 28.61f);
        //Debug.Log("Position player");
    }
}
