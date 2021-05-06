using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;

    private float speed = 5f;

    [SerializeField]
    private Vector3 velocity;

    [SerializeField]
    private float _gravity = 5f;

    [SerializeField]
    private float _jumpSpeed = 12f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        velocity = moveDirection * speed; 

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y += _jumpSpeed;
            }
        }
        else
        {
            velocity.y -= _gravity;
        }



        _controller.Move(velocity * Time.deltaTime);
    }
}
