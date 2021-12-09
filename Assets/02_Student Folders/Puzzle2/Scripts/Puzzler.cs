using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzler : MonoBehaviour
{
    public GameObject board;
    public GameObject[] pieces;
    
    [SerializeField]
    int numberOfPieces = 0;
    [SerializeField]
    int winningCombination = 0;
    
    public GameObject winMessage;
    private bool isDone;

    // Start is called before the first frame update
    void Start()
    {
      winMessage.SetActive(false);
      numberOfPieces = board.transform.childCount;   
      pieces = new GameObject[numberOfPieces];

      for( int i = 0; i < pieces.Length; i++) 
      {
        pieces[i] = board.transform.GetChild(i).gameObject;

      }
      
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space"))
        {
            winMessage.SetActive(false);
        }
    }

    public void correctPlacement()
    {
       winningCombination += 1;

       if(winningCombination == numberOfPieces) {
         Debug.Log("You are a winner!");
         winMessage.SetActive(true);

       }
    }

    public void wrongPlacement() {
      winningCombination -= 1;
    }

}
