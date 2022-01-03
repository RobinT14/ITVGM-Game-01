using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangePictureAndSound : MonoBehaviour
{
	public int Canvas01, Canvas02;
	void Start()
	{
		//Start the coroutine we define below named ExampleCoroutine.
		StartCoroutine(ExampleCoroutine());
	}

	IEnumerator ExampleCoroutine()
	{
		yield return new WaitForSeconds(Canvas01);
		GameObject.Find("Canvas02").SetActive(true);
		GameObject.Find("Canvas01").SetActive(false);
		yield return new WaitForSeconds(Canvas02);
		SceneManager.LoadScene("Scene1");
		// GameObject.Find("Canvas02").SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
