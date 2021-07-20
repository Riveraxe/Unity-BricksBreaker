using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Bricks;
    // Start is called before the first frame update
    private Judge _judge;
    public static GameManager instance;
    public bool GameOver;
    
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        _judge = FindObjectOfType<Judge>();
    }

    public void Update()
    {
        GameOver = _judge.GameOver;
        UIManger.instance.GameOVer(GameOver);
        passGame();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("FIrst");
    }

    void passGame()
    {
        if (Bricks.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            UIManger.instance.PassGame();
        }
    }
}

