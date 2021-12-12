using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toFirstPuzzle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("switch!");
        SceneManager.LoadScene("Puzzle1");
    }
}
