using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameStatus gameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPosition()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return theBall.IsGameStarted() ? theBall.transform.position.x : transform.position.x;
        }
        else
        {
            float mousePosInUnits = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
            return mousePosInUnits;
        }
    }
}
