using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPuzzle : MonoBehaviour
{
    public Texture2D image;
    public const int numberOfQuads = 4;
    public int timesToShuffle = 20;
    slidedImage noQuad;
    Vector2 startingQuad = new Vector2(numberOfQuads-1, numberOfQuads-1);
    slidedImage[,] numberedQuads;

    public static Vector2Int down;
    public static Vector2Int up;
    public static Vector2Int left;
    public static Vector2Int right;

int shuffleDecreaser;
    // Start is called before the first frame update
    void Start()
    {
        PuzzleElements();
    }

    void Update() {
if(Input.GetKeyDown(KeyCode.Space)){
Help();
}
}

    void PuzzleElements()
    {
       Texture2D[,] imageSlices = slidedImage.SliceImage(image, numberOfQuads);
       numberedQuads = new slidedImage[numberOfQuads, numberOfQuads];
       for(int j = 0; j < numberOfQuads; j++)  
       {
         for(int i = 0; i < numberOfQuads; i++)   
         {
           GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
           quad.transform.position = -Vector2.one * (numberOfQuads-1) * 0.5f + new Vector2(i,j);
           quad.transform.parent = transform;

           slidedImage clickedQuad = quad.AddComponent<slidedImage>();
           clickedQuad.chosenElement += changeQuadPosition;
           clickedQuad.Init(imageSlices[i,j]);
           numberedQuads[i,j] = clickedQuad;
           if(i == startingQuad.x && j == startingQuad.y)
           { 
             quad.SetActive(false);
             noQuad = clickedQuad;
           }
         }
       }
    }

    void changeQuadPosition(slidedImage quad) 
    {
      if((quad.transform.position - noQuad.transform.position).sqrMagnitude == 1) 
      {
        Vector2 help = noQuad.transform.position;
        noQuad.transform.position = quad.transform.position;
        quad.transform.position = help;
      }
    }

void Help() {
Debug.Log("in");
        shuffleDecreaser = timesToShuffle;
        while(shuffleDecreaser != 0) 
        {
          Shuffler();
          
        }
}

    void Shuffler() {
      Vector2Int left = new Vector2Int(-1,0);
      Vector2Int right = new Vector2Int(1,0);
      Vector2Int above = new Vector2Int(0,1);
      Vector2Int below = new Vector2Int(0,-1);
      Vector2Int[] neighbours = {left, right, above, below};
      Vector2Int help = new Vector2Int((int)noQuad.transform.position.x, (int)noQuad.transform.position.y);

      int random = Random.Range(0, neighbours.Length);
//Debug.Log(neighbours.Length);
      for(int i = 0; i < neighbours.Length; i++)
      { 
        Vector2Int neighbour = neighbours[(random+i)% neighbours.Length];
        Vector2Int moveQuad = help + neighbour;

        if(moveQuad.x >= 0 && moveQuad.x < numberOfQuads &&
           moveQuad.y >= 0 && moveQuad.y < numberOfQuads) {
          shuffleDecreaser--;
Debug.Log("Before: "+ "(x,y)" + moveQuad.x + moveQuad.y);
          changeQuadPosition(numberedQuads[moveQuad.x,moveQuad.y]);
Debug.Log("After: " + "(x,y)" + moveQuad.x + moveQuad.y);
          break;
        }
      }
    }
}
