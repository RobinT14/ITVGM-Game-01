using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfMemory : MonoBehaviour
{
    public AudioSource source = null;
    public void AudioStart()
    {
        source.Play();
    }

    public void ToScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
}
