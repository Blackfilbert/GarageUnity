using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float mouseSpeed = 10f;
    private Vector3 moveDirection;
    private float verticalRotationLimit = 80f;
    private float verticalRotation;

    private void Awake() {
        _rb = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        PlayerMove();
        CameraMove();
    }

    private void PlayerMove() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(h, 0, v);
        _rb.velocity = (transform.forward * v + transform.right * h) * speed * Time.deltaTime;
    }

    private void CameraMove() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.Rotate(Vector3.up * mouseX);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
