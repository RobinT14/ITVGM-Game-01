using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class slidingPuzzle : MonoBehaviour
{
    public Texture2D image;
    public const int numberOfQuads = 4;
    slidedImage noQuad;
    Vector2 startingQuad = new Vector2(numberOfQuads - 1, numberOfQuads - 1);

    slidedImage[,] numberedQuads;

    Vector3[,] starter;

    int shuffleDecreaser;

    //dontdestroy info
    GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

    // Start is called before the first frame update
    void Start()
    {                
        PuzzleElements();
        amounOfShuffles();

        PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
    }

    void PuzzleElements()
    {
        Texture2D[,] imageSlices = slidedImage.SliceImage(image, numberOfQuads);
        numberedQuads = new slidedImage[numberOfQuads, numberOfQuads];

        starter = new Vector3[numberOfQuads,numberOfQuads];
        for (int j = 0; j < numberOfQuads; j++)
        {
            for (int i = 0; i < numberOfQuads; i++)
            {
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = new Vector2(i, j);
                quad.transform.parent = transform;
                slidedImage clickedQuad = quad.AddComponent<slidedImage>();
                clickedQuad.chosenElement += changeQuadPosition;
                Vector2Int position = new Vector2Int(i,j);
                clickedQuad.Init(position, imageSlices[i, j]);
                numberedQuads[i, j] = clickedQuad;
                starter[i,j] = numberedQuads[i, j].transform.position;
                if (i == startingQuad.x && j == startingQuad.y)
                {
                    quad.SetActive(false);
                    noQuad = clickedQuad;
                }
            }
        }
    }

    void changeQuadPosition(slidedImage quad)
    {
        if ((quad.transform.position - noQuad.transform.position).sqrMagnitude == 1)
        {
            Vector2 emptyQuad = noQuad.transform.position;
            noQuad.transform.position = quad.transform.position;
            quad.transform.position = emptyQuad;
            isSolved();
        }
    }

    void amounOfShuffles()
    {
        for (int i = 0; i < 10; i++)
        {
            Shuffler();
        }
    }

    void Shuffler()
    {
        Vector2 left = new Vector2(-1, 0);
        Vector2 right = new Vector2(1, 0);
        Vector2 above = new Vector2(0, 1);
        Vector2 below = new Vector2(0, -1);
        Vector2[] neighbours = { left, right, above, below };
        Vector2 currentEmpty = new Vector2(noQuad.transform.position.x, noQuad.transform.position.y);

        int random = Random.Range(0, neighbours.Length);

        for (int i = 0; i < neighbours.Length; i++)
        {
            Vector2 neighbour = neighbours[(random + i) % neighbours.Length];
            Vector2 moveQuad = currentEmpty + neighbour; //current empty quad + offset
            int xCoord = (int)Mathf.Ceil(moveQuad.x);
            int yCoord = (int)Mathf.Ceil(moveQuad.y);

            if (moveQuad.x >= 0 && moveQuad.x < numberOfQuads &&
                moveQuad.y >= 0 && moveQuad.y < numberOfQuads)
            {
                changeQuadPosition(numberedQuads[xCoord, yCoord]);
                break;
            }
        }
    }

    void isSolved()
    {
        foreach(slidedImage quad in numberedQuads)
        {
            if(!(quad.startingPosition.x == quad.transform.position.x && 
               quad.startingPosition.y == quad.transform.position.y))
            {
                return;                   
            }
        }
        Debug.Log("You are a winner!"); 
        ShowImage();
	//statische beelden
        dontdestroyinfo.ShowTriggerobj1 = false;
	SceneManager.LoadScene("Puzzle1Memory");
    }


    void ShowImage()
    {
        Texture2D[,] imageSlices = slidedImage.SliceImage(image, numberOfQuads);
        numberedQuads = new slidedImage[numberOfQuads, numberOfQuads];

        starter = new Vector3[numberOfQuads,numberOfQuads];
        for (int j = 0; j < numberOfQuads; j++)
        {
            for (int i = 0; i < numberOfQuads; i++)
            {
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = new Vector2(i, j);
                quad.transform.parent = transform;
                slidedImage clickedQuad = quad.AddComponent<slidedImage>();
                clickedQuad.chosenElement += changeQuadPosition;
                Vector2Int position = new Vector2Int(i,j);
                clickedQuad.Init(position, imageSlices[i, j]);
                numberedQuads[i, j] = clickedQuad;
                starter[i,j] = numberedQuads[i, j].transform.position;
            }
        }
    }
}
