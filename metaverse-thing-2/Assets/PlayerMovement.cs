using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    bool moveForward;
    bool moveBack;
    bool moveLeft;
    bool moveRight;
    FloatingJoystick joystick;
    Rigidbody rb;
    [SerializeField] float moveSpeed;
    public bool isUsingJoystick;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        joystick = FindObjectOfType<FloatingJoystick>();
    }

    // Update is called once per frame
    void Update()
    {

        RigidbodyMovement();
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            isUsingJoystick = false;
        }

        // KeyboardInputs();
        // TransformMovement();
    }

    private void KeyboardInputs()
    {
        moveForward = Input.GetKey(KeyCode.W);
        moveBack = Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.D);
    }

    private void RigidbodyMovement()
    {
        isUsingJoystick = true;
        rb.velocity =
        new Vector3(joystick.Horizontal * moveSpeed + Input.GetAxis("Horizontal") * moveSpeed,
                    rb.velocity.y,
                    joystick.Vertical * moveSpeed + Input.GetAxis("Vertical") * moveSpeed);

        print("Setting velocity thru joystick");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            UIManager.instance.EnableShowProducts();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            UIManager.instance.DisableShowProducts();
        }
    }

    public void SetMovement(String data)
    {
        FlutterUnityPlugin.Message message = FlutterUnityPlugin.Messages.Receive(data);
        // float value = float.Parse(message.data);
        // v3 = new Vector3(value, value, value);

        if (data.Equals("forward"))
        {

        }
        if (data.Equals("back"))
        {

        }
        if (data.Equals("left"))
        {

        }
        if (data.Equals("right"))
        {

        }

        FlutterUnityPlugin.Messages.Send(message);
    }


    // public void SetRotationSpeed(string data)
    // {
    //     FlutterUnityPlugin.Message message = FlutterUnityPlugin.Messages.Receive(data);

    //     float value = float.Parse(message.data);

    //     v3 = new Vector3(value, value, value);

    //     message.data = "SetRotationSpeed: " + value;

    // FlutterUnityPlugin.Messages.Send(message);
    // }

    private void TransformMovement()
    {
        if (moveForward)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (moveLeft)
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (moveBack)
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (moveRight)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }
}
