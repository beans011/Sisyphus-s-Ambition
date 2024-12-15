using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAnimation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("yo");
            Animator animator = other.GetComponentInChildren<Animator>();
            //animator.SetBool("pushingBoulder", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("yo");
            Animator animator = other.GetComponentInChildren<Animator>();
            //animator.SetBool("pushingBoulder", false);
        }
    }
}
