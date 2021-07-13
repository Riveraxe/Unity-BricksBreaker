using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _self;

    private Vector2 NowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Rigidbody2D>();
        _self.velocity = new Vector2(0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_self.velocity);
    }
}
