using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Arrow : MonoBehaviour
{
   
    private bool IsRotatable;
    private bool IsLoadingEnded;


    private Vector3 currentAngle;
    private float TargetSpeedOfLoading { get; set; } = 220f;

    private float TargetSpeedUp { get; set; } = -2f;
    private float SpeedOfIncrease { get; set; } = 0.05f;
    private float SpeedUpAngle { get; set; } = -2f;

    [SerializeField] private float targetAngle = 270f;

    public double actualLoadingSpeed;
    private void Start()
    {
        IsRotatable = true;
        IsLoadingEnded = false;
        currentAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z < 2f && transform.eulerAngles.z > 0f)
        {
            transform.eulerAngles = new Vector3(currentAngle.x, currentAngle.y, 0f);
            IsRotatable = false;
        }
        //if (transform.eulerAngles.z > 270f)
        //{
        //    IsRotatable = false;
        //}

        if (IsRotatable)
        {
            if(targetAngle > TargetSpeedOfLoading)
            {
                targetAngle += TargetSpeedUp;
            }
            
            currentAngle = new Vector3(currentAngle.x, currentAngle.y,
                Mathf.LerpAngle(currentAngle.z, targetAngle, SpeedOfIncrease * Time.deltaTime));

            transform.eulerAngles = currentAngle;

            Debug.Log("angles: " + transform.eulerAngles.z);
        }

        if (IsLoadingEnded)
        {
            currentAngle = new Vector3(currentAngle.x, currentAngle.y,
                Mathf.LerpAngle(currentAngle.z, targetAngle, SpeedOfIncrease * Time.deltaTime));

            transform.eulerAngles = currentAngle;
        }

        float maxSpeed = 100f;
        float speedometrAngles = 270;

        actualLoadingSpeed = Math.Round(100 - transform.eulerAngles.z * maxSpeed / speedometrAngles, 2, MidpointRounding.ToEven);
            //Math.Ceiling(100 - transform.eulerAngles.z * maxSpeed / speedometrAngles);
        //Debug.Log("actualLoadingSpeed: " + actualLoadingSpeed);
    }



    private void OnMouseDown()
    {
        if(IsRotatable) 
        {
            TargetSpeedUp += SpeedUpAngle;
            targetAngle += -2f;
            SpeedOfIncrease += 0.15f;
        }

        //targetAngle = currentAngle.z + Speed;
    }

    public void StopLoading()
    {
        IsRotatable = false;
        targetAngle = 270f;
        SpeedOfIncrease = 5f;
        IsLoadingEnded = true;

    }

}
