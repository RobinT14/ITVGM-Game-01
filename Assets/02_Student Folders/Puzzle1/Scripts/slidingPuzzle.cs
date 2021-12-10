using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPuzzle : MonoBehaviour
{
	public Texture2D image;
	public const int numberOfQuads = 4;
	public int timesToShuffle = 1;
	slidedImage noQuad;
	Vector2 startingQuad = new Vector2(numberOfQuads - 1, numberOfQuads - 1);

	slidedImage[,] numberedQuads;

	public static Vector2Int down;
	public static Vector2Int up;
	public static Vector2Int left;
	public static Vector2Int right;
Vector2 starter;

public GameObject winMessage;

	int shuffleDecreaser;

	// Start is called before the first frame update
	void Start()
	{
                
		PuzzleElements();
                Help();
winMessage.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space"))
        {
            winMessage.SetActive(false);
        }
    }

/*
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Help();
		}
	}
*/

	void PuzzleElements()
	{
		Texture2D[,] imageSlices = slidedImage.SliceImage(image, numberOfQuads);
		numberedQuads = new slidedImage[numberOfQuads, numberOfQuads];
		for (int j = 0; j < numberOfQuads; j++)
		{
			for (int i = 0; i < numberOfQuads; i++)
			{
				GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
				quad.transform.position = new Vector2(i, j);
				quad.transform.parent = transform;
starter = quad.transform.position;
				slidedImage clickedQuad = quad.AddComponent<slidedImage>();
				clickedQuad.chosenElement += changeQuadPosition;
				clickedQuad.Init(imageSlices[i, j]);
				numberedQuads[i, j] = clickedQuad;
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
		// Debug.Log("in: " + quad.transform.position + noQuad.transform.position);
		if ((quad.transform.position - noQuad.transform.position).sqrMagnitude == 1)
		{
			Debug.Log("Bingo!");
			Vector2 help = noQuad.transform.position;
			noQuad.transform.position = quad.transform.position;
			quad.transform.position = help;
			// Debug.Log("hehe: " + quad.transform.position + noQuad.transform.position);
isSolved();
		}
	}

	void Help()
	{
		Debug.Log("Shuffle");
		shuffleDecreaser = timesToShuffle;
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
		Vector2[] neighbours = { left, right, above, below }; //Is ok
		Vector2 help = new Vector2(noQuad.transform.position.x, noQuad.transform.position.y); //Is ok with noQuad coords

		int random = Random.Range(0, neighbours.Length);

		for (int i = 0; i < neighbours.Length; i++)
		{
			Vector2 neighbour = neighbours[(random + i) % neighbours.Length];
			Vector2 moveQuad = help + neighbour; //current empty quad + offset

			Debug.Log("Wissel: " + "(" + moveQuad.x + "," + moveQuad.y + ") " + "MET=>" + noQuad.transform.position);

			int xCoord = (int)Mathf.Ceil(moveQuad.x);
			int yCoord = (int)Mathf.Ceil(moveQuad.y);

			if (moveQuad.x >= 0 && moveQuad.x < numberOfQuads &&
			   moveQuad.y >= 0 && moveQuad.y < numberOfQuads)
			{
				Debug.Log("Bingo! i=" + i);
				// shuffleDecreaser--;
				changeQuadPosition(numberedQuads[xCoord, yCoord]); //input 0,1,2,3 (positions)
				break;
			}
		}
	}

        void isSolved()
        {
bool allMatchingQuads=false;
            foreach(slidedImage quad in numberedQuads)
            {
                if(starter.x == quad.transform.position.x && starter.y == quad.transform.position.y) 
                {
                    Debug.Log("No winner");
                    allMatchingQuads = true;
                } 
                else allMatchingQuads = false;               
            }

            if(allMatchingQuads) {
                    Debug.Log("You are a winner!");
                    winMessage.SetActive(true);
            }
             
        }

}
