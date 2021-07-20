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
    private float SpeedX;
    private float SpeedY;
    public Transform GroundCheck;
    public Transform Board;
    public float GroundRadius;
    public bool isGround;
    //public LayerMask BreakLayer;
    public LayerMask GroundLayer;
    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Rigidbody2D>();
        _self.velocity = new Vector2(0, -MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        PhysicCheck();
        PushBall();
    }

    void PhysicCheck()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius,GroundLayer);
        if (isGround)
        {
            Debug.Log("------zhuang--------");
            SpeedX = _self.position.x - Board.position.x;
            SpeedY = (float)Math.Sqrt(MaxSpeed * MaxSpeed - SpeedX * SpeedX);
            //float HorzonInput = Input.GetAxis("Horizontal");
            //BallForce = new Vector2(SpeedX*10, 0);
            //_self.AddForce(BallForce);
            _self.velocity = new Vector2(SpeedX, SpeedY);
            
            //Debug.Log(SpeedX.ToString("0.00")+SpeedY.ToString("0.00"));
        }
    }

    void PushBall()
    {
        if (Math.Abs(_self.velocity.y) <= 1 )
        {
            _self.velocity = new Vector2(_self.velocity.x, 2);
        }
        
    }

    //void BallToBoard
    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheck.position,GroundRadius);
    }
}
