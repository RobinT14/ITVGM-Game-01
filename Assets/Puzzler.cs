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
    
    // Start is called before the first frame update
    void Start()
    {
      numberOfPieces = board.transform.childCount;   
      pieces = new GameObject[numberOfPieces];

      for( int i = 0; i < pieces.Length; i++) 
      {
        pieces[i] = board.transform.GetChild(i).gameObject;

      }
      
    }

    // Update is called once per frame
    public void correctPlacement()
    {
       winningCombination += 1;

       if(winningCombination == numberOfPieces) {
         Debug.Log("You are a winner!");
       }
    }

    public void wrongPlacement() {
      winningCombination -= 1;
    }

}
