using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostersGO : MonoBehaviour
{
    public AudioSource source = null;

    public void PosterAudio()
    {
        source.Play();
    }

    public void OnPostersComplete()
    {
        SceneManager.LoadScene("Poster");
        Debug.Log("Loaded poster scene!");
    }
}
