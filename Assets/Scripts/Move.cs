using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D _self;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Rigidbody2D>();
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float HorzonInput = Input.GetAxis("Horizontal");
        _self.velocity = new Vector2(HorzonInput * speed, _self.velocity.y);
    }
}
