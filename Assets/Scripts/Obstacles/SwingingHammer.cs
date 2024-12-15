using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingHammer : MonoBehaviour
{
    public float speed;
    public float limit;
    private float random;

    private void Start()
    {
        random = Random.Range(0.0f, 1.0f);
    }

    private void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random * speed);
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }
}
