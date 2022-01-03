using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangePictureAndSound : MonoBehaviour
{
	public int Canvas01, Canvas02;
	
	//dontdestroy info
	GameObject PositionPlayer;
    public DontDestroy dontdestroyinfo;

	// animation variables
	public Animator animator;
	public string chosenAnimation = null;

	void Start()
	{
		//Start the coroutine we define below named ExampleCoroutine.
		StartCoroutine(ExampleCoroutine());

		PositionPlayer = GameObject.Find("PlayerPosition");
        dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
	}

	IEnumerator ExampleCoroutine()
	{
		yield return new WaitForSeconds(Canvas01);
		GameObject.Find("Canvas02").SetActive(true);
		GameObject.Find("Canvas01").SetActive(false);
		yield return new WaitForSeconds(Canvas02);

		Debug.Log("Hey, can you see me?");
		dontdestroyinfo.ShowPosterTrigger = false;
        animator.SetTrigger(chosenAnimation);
        // GameObject.Find("Canvas02").SetActive(false);
    }

	// Update is called once per frame
	void Update()
	{

	}
}
