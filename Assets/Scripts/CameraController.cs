using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    private Vector3 lastMousePosition;
    
    public Transform pivot;
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 2.0f;
    public float maxZoomDistance = 10.0f; 

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - lastMousePosition;

            var pivotPosition = pivot.position;
            transform.RotateAround(pivotPosition, Vector3.up, delta.x * rotationSpeed);
            transform.RotateAround(pivotPosition, transform.right, -delta.y * rotationSpeed);

            lastMousePosition = Input.mousePosition;
        }

        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        var cachedTransform = transform;
        var zoomDirection = zoomInput * zoomSpeed * cachedTransform.forward;
        var newPosition = cachedTransform.position + zoomDirection;

        var position = pivot.position;
        newPosition = Vector3.ClampMagnitude(newPosition - position, maxZoomDistance) + position;
        newPosition = Vector3.ClampMagnitude(newPosition - position, maxZoomDistance) + position;

        transform.position = newPosition;
    }
}

