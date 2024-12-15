using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RotateCamera(-rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RotateCamera(rotationSpeed);
        }
    }

    void RotateCamera(float angle)
    {
        Vector3 rotationAxis = player.up;
        transform.RotateAround(player.position, rotationAxis, angle);
    }
}
