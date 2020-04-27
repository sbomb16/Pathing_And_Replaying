using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirsPerson : MonoBehaviour {

    private const float Y_ANGLE_MIN = 17f;
    private const float Y_ANGLE_MAX = 17f;

    private const float X_ANGLE_MIN = -100f;
    private const float X_ANGLE_MAX = 100f;


    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float yDistance = 5f;
    public float zDistance = 3f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;

    }
    private void Update()
    {
        //currentX += Input.GetAxis("Mouse X");
        //currentY += Input.GetAxis("Mouse Y");

        //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        //currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, yDistance, -zDistance);
        Quaternion rotation = Quaternion.Euler(yDistance, 0, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

}
