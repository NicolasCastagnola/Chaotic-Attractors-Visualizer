using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalSpeed = 5.0f;

    private bool cursorLocked;
    
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            cursorLocked = !cursorLocked;
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontalInput, 0, verticalInput) * (movementSpeed * Time.deltaTime);
        transform.Translate(movement);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        var rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
        transform.Rotate(rotation);

        float verticalMovement = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            verticalMovement = 1.0f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            verticalMovement = -1.0f;
        }

        var verticalTranslation = Vector3.up * (verticalMovement * verticalSpeed * Time.deltaTime);
        transform.Translate(verticalTranslation);
    }
}
