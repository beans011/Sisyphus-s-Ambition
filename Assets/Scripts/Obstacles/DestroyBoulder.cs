using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoulder : MonoBehaviour
{
    public float dieTime;

    void Start()
    {
        Invoke("Die", dieTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
