using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Script : MonoBehaviour
{
    float[] rotate = {0, 90, 180, 270};
    public float[] winningCombination;
    [SerializeField]
    bool isCorrect = false;

    int possibilities = 1;

    Puzzler help;

    private void Awake() {
        help = GameObject.Find("Puzzler").GetComponent<Puzzler>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        int rand = Random.Range(0, rotate.Length);
        transform.eulerAngles = new Vector3(0,0,rotate[rand]);

        possibilities = winningCombination.Length;

        if(possibilities > 1) 
        {
            if((int)transform.eulerAngles.z == winningCombination[0] || 
               transform.eulerAngles.z == winningCombination[1]) 
            {
                isCorrect = true;
                help.correctPlacement();
            }
        }
        else 
        {
            if((int)transform.eulerAngles.z == winningCombination[0]) 
            {
                isCorrect = true;
                help.correctPlacement();
            }
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0,0,90f)); 
        if(possibilities > 1) 
        {
            if(((int)transform.eulerAngles.z == winningCombination[0] || 
               transform.eulerAngles.z == winningCombination[1]) && 
               isCorrect == false) 
            {
                isCorrect = true;
                help.correctPlacement();
            }
            else if(isCorrect == true) 
            {
                isCorrect = false;
                help.wrongPlacement();
            }
        }
        else 
        {
            if((int)transform.eulerAngles.z == winningCombination[0] && isCorrect == false) 
            {
                isCorrect = true;
                help.correctPlacement();
            }
            else if(isCorrect == true) 
            {
                isCorrect = false;
                help.wrongPlacement();
            }        
        }
    }
}
