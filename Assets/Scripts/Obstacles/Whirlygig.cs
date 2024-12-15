using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlygig : MonoBehaviour
{
    public Transform pole;
    public float rotationSpeed = 2f;

    void Update()
    {
        
        RotateObject();
    }


    void RotateObject()
    {

        Vector3 rotationAxis = pole.up;

        transform.RotateAround(pole.position, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
