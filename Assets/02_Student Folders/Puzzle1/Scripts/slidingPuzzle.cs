using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPuzzle : MonoBehaviour
{
    public Texture2D image;
    public const int numberOfQuads = 4;
    slidedImage noQuad;
    Vector2 startingQuad = new Vector2(numberOfQuads-1, numberOfQuads-1);

    // Start is called before the first frame update
    void Start()
    {
        PuzzleElements();
    }

    void PuzzleElements()
    {
       Texture2D[,] imageSlices = slidedImage.SliceImage(image, numberOfQuads);

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
}
