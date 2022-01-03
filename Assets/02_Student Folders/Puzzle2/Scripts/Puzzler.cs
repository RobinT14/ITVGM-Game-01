using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzler : MonoBehaviour
{
    public GameObject board;
    public GameObject[] pieces;
    
    [SerializeField]
    int numberOfPieces = 0;
    [SerializeField]
    int winningCombination = 0;
    
    private bool isDone;

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

    public void correctPlacement()
    {
        winningCombination += 1;
        if(winningCombination == numberOfPieces) 
        {
            Debug.Log("You are a winner!");
            SceneManager.LoadScene("Scene1");
        }
    }

    public void wrongPlacement() 
    {
        winningCombination -= 1;
    }
}
