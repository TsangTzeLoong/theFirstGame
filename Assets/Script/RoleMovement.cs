using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RoleMovement : MonoBehaviour
{
    [SerializeField] 
    private float maxSpeed = 10f; //最大速度
    [SerializeField] 
    private float maxAcceleration = 10f; //最大加速度
    [SerializeField]
    private float jumpHeight = 2f;//跳跃能到达的预期高度
    private Vector2 jumpDirection;//跳跃的方向

    private Rigidbody2D body;
    private float playerInput;
    private Vector2 targetSpeed;
    private Vector2 velocity;

    private Vector2 groundNormal;
    private bool IsOnGround;
    private void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    private bool isTryJump = false;
    void Update(){
        playerInput = Input.GetAxis("Horizontal");
        playerInput = Mathf.Min(playerInput, 1);
        //记录跳跃按键，这里不能直接用赋值，因为Update执行间隔和FixedUpdate不同
        //可能当前按下了跳跃，但FixedUpdate却还没来得及跳起来，却又执行了一次Update
        //如果直接用等号赋值，此时就会被视作没有按下跳跃键
        //所以，应当严格保证只有在FixedUpdate起跳后，isTryJump才为false
        isTryJump |= Input.GetButtonDown("Jump");
    }

    void OnCollisionStay2D(Collision2D collision){
        for(int i = 0; i < collision.contactCount; ++i){
            var normal = collision.GetContact(i).normal;
            if(normal.y > 0){
                IsOnGround = true;
                groundNormal += normal;
            }
        }
    }

    void FixedUpdate(){
        velocity = body.velocity;

        groundNormal.Normalize();
        Move();
        Jump();
        groundNormal = Vector2.up;

        body.velocity = velocity;
        IsOnGround = false;
    }

    void Jump(){
        if(isTryJump){
            isTryJump = false;
            if (IsOnGround){
                jumpDirection = groundNormal;
            }
            else return;
            // vt = 根号(2gh)，Unity的y方向重力是-9.81，所以计算时g取个负号，使其成正数
            var jumpSpeed = Mathf.Sqrt(2 * -Physics.gravity.y * jumpHeight);
            //通过投影获取当前跳跃方向的速度
            var curSpeed = Vector2.Dot(velocity, jumpDirection);
            if(curSpeed > 0){
                jumpSpeed = Mathf.Max(jumpSpeed - curSpeed, 0);
            }
            velocity += jumpSpeed * jumpDirection;
        }
    }

    void Move(){
        var acceleration = maxAcceleration * Time.fixedDeltaTime;
        targetSpeed = new Vector2(playerInput, 0f) * maxSpeed;
        var xAixs = GetProjectOnPlane(Vector2.right).normalized;
        var curVelocityX = Vector2.Dot(velocity, xAixs);
        var newVelocityX = Mathf.MoveTowards(curVelocityX, targetSpeed.x, acceleration);
        velocity += xAixs * (newVelocityX - curVelocityX);
    }

    Vector2 GetProjectOnPlane(Vector2 curVector){
        return curVector - groundNormal * Vector2.Dot(curVector, groundNormal);
    }
}