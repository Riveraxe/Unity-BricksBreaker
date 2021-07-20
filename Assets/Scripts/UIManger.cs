using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject StartPanel;
    public static UIManger instance;
    public GameObject GameoverPanel;

    public GameObject GamePassPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
    }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameOVer(bool Gameover)
    {
        GameoverPanel.SetActive(Gameover);
        //Time.timeScale = 0;
    }

    public void PassGame()
    {
        GamePassPanel.SetActive(true);
    }
}
