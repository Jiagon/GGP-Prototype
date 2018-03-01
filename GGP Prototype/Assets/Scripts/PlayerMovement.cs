using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Camera cam;
    CursorLockMode cursor;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float maxSpeed = 10f;

    float rotY = 0.0f;              // Rotation around the up / y axis - keyboard Q / E
    float rotX = 0.0f;              // Rotation around the right / x axis - mouse movement
    float speed = 4f;

    // Use this for initialization
    void Start() {
        cursor = CursorLockMode.Locked;
        Cursor.lockState = cursor;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update() {
        // Escapes program - more importantly escapes CursorLockMode.Locked so you can exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // For player strafing / movement
        Vector3 pos = transform.position;
        float moveSpeed = 15;

        // For camera movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        // rotX = up and down camera
        // rotY = left and right camera
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
        // Clamping rotations
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        
        // For rotating and moving in the forward direction
        Vector3 RIGHT = transform.TransformDirection(Vector3.right);
        Vector3 LEFT = transform.TransformDirection(Vector3.left);
        Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

        // Speed up / slow down
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed += Time.deltaTime * 3;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            speed -= Time.deltaTime * 3;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }

        // Strafe up, down, left, right
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += Time.deltaTime * moveSpeed;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= Time.deltaTime * moveSpeed;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += RIGHT * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += LEFT * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * -1;
        }

        // Rotate camera around Y axis
        if (Input.GetKey(KeyCode.Q))
        {
            rotY -= Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotY += Time.deltaTime * moveSpeed;
        }

        // Moves player forward
        transform.localPosition += FORWARD * speed * Time.deltaTime;

        // Setting Rotation and forward vector
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        transform.forward = transform.rotation * transform.forward;
    }
}
