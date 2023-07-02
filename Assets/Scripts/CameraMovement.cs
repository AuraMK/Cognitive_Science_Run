using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public float speedUp;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((cameraSpeed * speedUp)* Time.deltaTime, 0, 0); // no position changes, moving frame
    }
}
