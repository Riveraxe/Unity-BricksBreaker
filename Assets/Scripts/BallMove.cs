using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float MaxSpeed;
    
    private Rigidbody2D _self;
    private Vector2 BallForce;

    private Vector2 NowSpeed;
    public Transform GroundCheck;
    public Transform Brick;
    public float GroundRadius;
    public bool isGround;
    public LayerMask BreakLayer;
    public LayerMask GroundLayer;
    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Rigidbody2D>();
        _self.velocity = new Vector2(0, -10);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        PhysicCheck();
        MeetBricks();
    }

    void PhysicCheck()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius,GroundLayer);
        if (isGround && _self.velocity.magnitude < MaxSpeed)
        {
            Debug.Log("------zhuang--------");
            float HorzonInput = Input.GetAxis("Horizontal");
            BallForce = new Vector2(HorzonInput*100, 0);
            _self.AddForce(BallForce);
        }
    }

    void MeetBricks()
    {
        if (Physics2D.OverlapCircle(GroundCheck.position,GroundRadius,BreakLayer))
        {
            Invoke("SetBrick",0.1f);
        }
    }

    void SetBrick()
    {
        Brick.gameObject.SetActive(false);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheck.position,GroundRadius);
    }
}
