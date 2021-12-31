using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondPuzzleGO : MonoBehaviour
{
    public AudioSource source = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AudioStart()
    {
        //source = GetComponent<AudioSource>();
        source.Play(0);
    }

    public void OnFadeComplete2()
    {
        SceneManager.LoadScene("Puzzle2");
        Debug.Log("Succesfully loaded puzzle 2");
    }

}
