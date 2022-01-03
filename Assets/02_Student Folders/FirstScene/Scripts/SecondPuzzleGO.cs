using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondPuzzleGO : MonoBehaviour
{
    public AudioSource source = null;

    public void AudioStart()
    {
        source.Play(0);
    }

    public void OnFadeComplete2()
    {
        SceneManager.LoadScene("Puzzle2");
        Debug.Log("Succesfully loaded puzzle 2");
    }

}
