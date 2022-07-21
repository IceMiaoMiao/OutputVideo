using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float sprintSpeed;
    public float jumpSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;

    public float gravity;
    private Vector3 velocity;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGround = true;
    public bool isDoubleJump = false;
    public bool isJump = true;





    private void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    private void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -0.5f * gravity * Time.deltaTime * Time.deltaTime;

        }
        //鼠标控制视野
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);



        if (Input.GetButtonDown("Jump"))
        { //跳跃&连续跳跃
            if (isGround)
            {
                velocity.y = jumpSpeed;
                isJump = true;
                isGround = false;

            }
            else if (isDoubleJump && !isGround && isJump)
            {
                velocity.y = jumpSpeed;
                isJump = true;
 
            }

        }
        if (Input.GetMouseButton(0))//鼠标左键快速下落
        {
            velocity.y -= 100 * gravity * Time.deltaTime;
            isJump = false;

        }
        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cc.Move(dir * Time.deltaTime * sprintSpeed);
  
        }

        if (Input.GetKeyDown(KeyCode.R))//按下R键返回起点
        {
            SceneManager.LoadScene(1);
        }

    }

}