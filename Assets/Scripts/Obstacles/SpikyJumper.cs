using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyJumper : MonoBehaviour
{
    [Header("Pop Spiky thing")]
    public Transform spikyThing; 
    public float popUpHeight = 1f;
    public float popUpSpeed = 1f;
    public float popDownSpeed = 1f;
    public float interval = 2f;

    [Header("Move Spiky thing")]
    public float popLeftDistance = 3.0f;
    public float popRightDistance = 3.0f;
    public float moveSpeed = 1;
    public bool canMove = false;

    private bool isPopping = false;
    private Vector3 originalPosition;
    private float popStartTime;
    private bool movingRight = true;

    void Start()
    {
        spikyThing = GetComponent<Transform>();
        originalPosition = spikyThing.position;
        InvokeRepeating("TogglePopUp", 0f, interval);
    }

    void TogglePopUp()
    {
        if (!isPopping)
        {
            popStartTime = Time.time;
            isPopping = true;
        }
        else
        {
            popStartTime = Time.time;
            isPopping = false;
        }
    }

    public void FixedUpdate()
    {
        if (isPopping)
        {
            float elapsedTime = Time.time - popStartTime;
            if (spikyThing.position.y < originalPosition.y + popUpHeight)
            {
                spikyThing.position += Vector3.up * popUpSpeed * elapsedTime;
            }
        }
        else
        {
            float elapsedTime = Time.time - popStartTime;
            if (spikyThing.position.y > originalPosition.y)
            {
                spikyThing.position -= Vector3.up * popDownSpeed * elapsedTime;
            }
        }

        if (canMove) 
        {
            MoveSideToSide();        
        }
    }

    public void MoveSideToSide()
    {
        if (canMove)
        {
            float moveDistance = moveSpeed * Time.deltaTime;

            if (movingRight && spikyThing.position.x < originalPosition.x + popRightDistance)
            {
                spikyThing.position += Vector3.right * moveDistance;
            }
            else if (!movingRight && spikyThing.position.x > originalPosition.x - popLeftDistance)
            {
                spikyThing.position -= Vector3.right * moveDistance;
            }

            if (movingRight && spikyThing.position.x >= originalPosition.x + popRightDistance)
            {
                movingRight = false;
            }
            else if (!movingRight && spikyThing.position.x <= originalPosition.x - popLeftDistance)
            {
                movingRight = true;
            }
        }
    }
}
