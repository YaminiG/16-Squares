using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationScript : MonoBehaviour
{

    float rotSpeed = 200;
    bool isDragging = false;
    bool isSelected = false;

    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public Camera camera;

    public Light selectLight;
    public MeshRenderer meshRenderer;

    // Rotation
    private void OnMouseDrag()
    {
        if (isSelected)
        {
            Debug.Log("ON MOUSE DRAG");

            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            //float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotX);
            //transform.Rotate(Vector3.right, -rotY);
            isDragging = true;
        }
        
    }

    private void OnMouseUp()
    {
        Debug.Log("ON MOUSE UP");
        //if (!isDragging)
        //{
            isSelected = !isSelected;
            selectLight.enabled = isSelected;
            meshRenderer.enabled = isSelected;
        //}
        isDragging = false;
    }


    private void Start()
    {
        Debug.Log("Starting...#");
        camera = gameObject.GetComponent<Camera>();
        selectLight = gameObject.GetComponent<Light>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
  
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Debug.Log("Touch Count 2");
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            // If the camera is orthographic...
            if (camera.orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
            }
        }
    }
    
}
