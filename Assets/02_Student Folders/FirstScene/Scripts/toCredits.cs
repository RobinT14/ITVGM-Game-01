using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toCredits : MonoBehaviour
{
    // animation variables
    public Animator animator;
    public string chosenAnimation = null;

    public void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger(chosenAnimation);
        Debug.Log("Activated credits");
    }
}
