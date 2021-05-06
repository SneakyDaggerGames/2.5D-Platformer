using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float _gravity = 1f;

    [SerializeField]
    private float _jumpSpeed = 12f;

    [SerializeField]
    private float _yVelocity;

    private bool canDoubleJump = false;

    [SerializeField]
    private int playerCoins = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            playerCoins += 1;
        }
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
                canDoubleJump = true;
            }
        }
        else
        {
            if (canDoubleJump == true && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpSpeed;
                canDoubleJump = false;
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
