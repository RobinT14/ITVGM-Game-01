using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsGO : MonoBehaviour
{
    public AudioSource source = null;

    void CreditAudio()
    {
        source.Play();
    }

    public void OnGameComplete()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Loaded credit scene!");
    }
}
