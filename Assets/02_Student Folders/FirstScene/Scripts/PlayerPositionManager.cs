using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public Transform Player;

    private Vector3 positionVector;
    public DontDestroy SavedPosition;
    GameObject PositionPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PositionPlayer = GameObject.Find("PlayerPosition");
        SavedPosition = PositionPlayer.GetComponent<DontDestroy>();
        //Debug.Log("GetComponent is gedaan");
        //player wordt verplaatst naar de plek dat gesaved is
        positionVector = SavedPosition.PlayerPosition - new Vector3 (0,0,1);
        Player.position = positionVector;
        //Player.position = new Vector3(-22.12f, -1.22f, 28.61f);
        //Debug.Log("Position player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
