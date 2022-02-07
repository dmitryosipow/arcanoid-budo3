using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    private Ball _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ball))
        {
            _ball.Restart();
            HUDManager.Instance.ChangeHealth(-1);
        }
    }
}