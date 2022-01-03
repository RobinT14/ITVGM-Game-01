using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toPosterScene : MonoBehaviour
{
	// transportation location
	private bool startgame = true;
	GameObject PositionPlayer;
	public DontDestroy dontdestroyinfo;

	// animation variables
	public Animator animator;
	public string chosenAnimation = null;

	void Start() { 
		PositionPlayer = GameObject.Find("PlayerPosition");
		dontdestroyinfo = PositionPlayer.GetComponent<DontDestroy>();
		startgame = false;
	}

	void Update()
	{
		if (!dontdestroyinfo.ShowPosterTrigger)
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (dontdestroyinfo.ShowPosterTrigger)
		{
			dontdestroyinfo.SavePosition();
			animator.SetTrigger(chosenAnimation);
			Debug.Log("Activated animation!");
		}
	}
}
