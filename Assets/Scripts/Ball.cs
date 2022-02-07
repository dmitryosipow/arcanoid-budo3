using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [Header("Base Settings")]
    public Rigidbody2D Rb;
    public float speed;
    public Vector2 direction;
    
    [Header("Pad Settings")]
    public Transform padTransform;
    public float yOffsetFromPad;

    [Header("Pad audio")]
    public AudioSource audioSource;
    

    private bool _isStarted;


    #region Unity Lifecycle

    private void Start()
    {

    }

    private void Update()
    {
        if (_isStarted)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }

        MoveBallWithPad();
    }
    
    public void Restart()
    {
        _isStarted = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.Play();
    }

    private void MoveBallWithPad()
    {
        Vector3 currentPosition = padTransform.position;
        currentPosition.y += yOffsetFromPad;
        transform.position = currentPosition;
    }

    #endregion
    
    #region Private methods

    private void StartBall()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), 1);
        Rb.velocity = speed * direction.normalized;
        _isStarted = true;
    }

    #endregion
}
