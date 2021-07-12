﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerater : MonoBehaviour
{

    public enum Direction { up, down, left, right };
    public Direction direction;

    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;



    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset,yOffset;
    public LayerMask roomLayer;

    public List<Room> rooms = new List<Room>();
        // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab,generatorPoint.position, Quaternion.identity).GetComponent<Room>());

            CHangePointPos();

            //Change point position
            

        }

        rooms[0].GetComponent<SpriteRenderer>().color = startColor;
        //endRoom = rooms[0].gameObject;


        //find endRoom
        foreach(var room in rooms)
        {
          //if(room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
        //  {
      //      endRoom = room.gameObject;
      //    }
          SetupRoom(room, room.transform.position);
        }
        //endRoom.GetComponent<SpriteRenderer>().color = endColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CHangePointPos()
    {
        do
        {
            direction = (Direction)Random.Range(0,4);

            switch(direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0,yOffset,0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0,-yOffset,0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset,0,0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset,0,0);
                    break;
            }
        } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));
    }

    public void SetupRoom(Room newRoom, Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0,yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0,-yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);
        
        newRoom.UpdateRoom();
    }
}
