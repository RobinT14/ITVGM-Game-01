using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePictureAndSound : MonoBehaviour
{
	void Start()
	{
		//Start the coroutine we define below named ExampleCoroutine.
		StartCoroutine(ExampleCoroutine());
	}

	IEnumerator ExampleCoroutine()
	{
		yield return new WaitForSeconds(5);
		GameObject.Find("Canvas02").active = true;
		GameObject.Find("Canvas01").active = false;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
