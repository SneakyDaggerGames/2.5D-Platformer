using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;

    private float speed = 5f;

    [SerializeField]
    private float _gravity = 1f;

    [SerializeField]
    private float _jumpSpeed = 12f;

    [SerializeField]
    private float _yVelocity;

    void Start()
    {
        Application.targetFrameRate = 60;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 velocity = moveDirection * speed; 

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpSpeed;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
