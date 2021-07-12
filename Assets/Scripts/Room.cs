using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{

    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;
    public int stepToStart;
    public Text text;
    void Start()
    {
      doorRight.SetActive(roomRight);
      doorLeft.SetActive(roomLeft);
      doorUp.SetActive(roomUp);
      doorDown.SetActive(roomDown);
      
    }

    // Update is called once per frame
    public void UpdateRoom()
    {
      stepToStart = (int)(Mathf.Abs(transform.position.x/18) + Mathf.Abs(transform.position.y/9));

      text.text = stepToStart.ToString();
    }
}
