using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // configuration paramaters
    float minX = 1f;
    float maxX = 15f;
    float screenWidthInUnits = 20f;

    // cached references
    GameSession theGameSession;
    Ball theBall;

    // Use this for initialization
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
        SetPaddleSize();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private void SetPaddleSize()
    {
        var mode = theGameSession.mode;
        if(mode == 1)
        {
            transform.localScale = new Vector3(2f, 1f, 1f);
            minX = 2f;
            maxX = 18f;
        }
        else if (mode == 2)
        {
            transform.localScale = new Vector3(1.5f, 1f, 1f);
            minX = 1.5f;
            maxX = 18.5f;
        }
        else if (mode == 3)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            minX = 1f;
            maxX = 19f;
        }
        else
        {
            return;
        }

    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

}