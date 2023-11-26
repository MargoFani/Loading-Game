using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   
    private Camera myCamera;
    private Vector3 screenPos;
    private float angleOffset = -5f;
    private float zRotation = 0f;
    private bool IsRotatable;


    private Vector3 currentAngle;
    private float speed = -5f;
    private float targetAngle = 0f;

    private void Start()
    {
        myCamera = Camera.main;
        IsRotatable = true;
        currentAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z < 226f && transform.eulerAngles.z > 225f)
        {
            
            IsRotatable = false;
            Debug.Log("IsRotatable: " + IsRotatable);
        }

        if (IsRotatable)
        {
            targetAngle = currentAngle.z + speed;

            currentAngle = new Vector3(currentAngle.x, currentAngle.y,
                Mathf.LerpAngle(currentAngle.z, targetAngle, Time.deltaTime));

            transform.eulerAngles = currentAngle;
        }

    }



    private void OnMouseDown()
    {
        if(IsRotatable) speed -= 5;

    }
}
