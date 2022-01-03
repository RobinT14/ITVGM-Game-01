using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangePictureAndSound : MonoBehaviour
{
	void Start()
	{
		//Start the coroutine we define below named ExampleCoroutine.
		StartCoroutine(ExampleCoroutine());
	}

	IEnumerator ExampleCoroutine()
	{
		yield return new WaitForSeconds(2);
		GameObject.Find("Canvas02").SetActive(true);
		GameObject.Find("Canvas01").SetActive(false);
		yield return new WaitForSeconds(14);
		SceneManager.LoadScene("Scene1");
		// GameObject.Find("Canvas02").SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
