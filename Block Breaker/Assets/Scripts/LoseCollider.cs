using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameStatus gameStatus;
    Ball theBall;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameStatus.LoseHeart();
        theBall.resetLaunch();
    }
}
