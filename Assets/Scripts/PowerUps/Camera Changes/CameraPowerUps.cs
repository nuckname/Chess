using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPowerUps : MonoBehaviour
{
    /*#
     * Vision:
        easy: change zooms super far out.
        camera changes angle randomly.
        camera zooms in one sqaure.
    */
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Adjust this variable to control the camera's rotation speed
    public float rotationSpeed = 1.0f;
    /*
    private void Update()
    {
        // Get the current rotation of the camera
        Quaternion currentRotation = transform.rotation;

        // Calculate the desired rotation increment based on the rotation speed
        float rotationIncrement = rotationSpeed * Time.deltaTime;

        // Calculate the new rotation around the Z-axis
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, rotationIncrement) * currentRotation;

        // Apply the new rotation to the camera
        transform.rotation = desiredRotation;
    }
    */
    


    private void CameraZoomOut()
    {
        camera.orthographicSize = 9.5f;
        //med, camera.size = 9.5f
        //hard, 30.5f
    }
    private void CameraRotation()
    {
        //camera.transform.rotation = Quaternion.Slerp(1);
    }

}
