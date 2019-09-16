using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float runningSpeedMultiplier;
    public float rotationSpeed;

    private float _runningSpeedMultiplier = 1;
    private float xRotation;
    private float yRotation;
    private Rigidbody rigidBody;
    private Transform player;
    private Animator _animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        Cursor.visible = false;
    }

    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        xRotation = Mathf.Clamp(xRotation, -45, 45);
        yRotation -= Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        if (Input.GetKey(KeyCode.B))
        {
            _animator.SetBool("Dance", true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            _animator.SetBool("Dance", false);
        }
        if (!(Input.GetKeyUp(KeyCode.UpArrow) || 
            Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.W) || 
            Input.GetKeyUp(KeyCode.S)))
        {
            _animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("isLeftStrafe", false);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("isRightStrafe", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("isLeftStrafe", true);
            rigidBody.velocity = new Vector3(-speed, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isRightStrafe", true);
            rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, rigidBody.velocity.z);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isWalking", true);
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, speed * _runningSpeedMultiplier);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("isWalking", true);
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -speed * _runningSpeedMultiplier);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("isRunning", true);
            _runningSpeedMultiplier = runningSpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetBool("isRunning", false);
            _runningSpeedMultiplier = 1;
        }
        player.eulerAngles = new Vector3(xRotation, yRotation, player.eulerAngles.z);
        rigidBody.rotation = Quaternion.Euler(player.eulerAngles);
    }
}
