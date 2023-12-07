using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Arrow : MonoBehaviour
{
    private bool IsLoadingEnded;
    public bool CanClick;

    public bool CanDecrise = true;
    private Vector3 currentAngle;
    //то значение к которому стрелка движется
    public float TargetSpeedOfLoading { get; set; } = 220f;
    //то на сколько градусов в единицу времени приближжается стрелка к TargetSpeedOfLoading
    public float TargetSpeedUp { get; set; } = -2f;

    //то на сколько увеличивается угол при клике мышкой
    public float SpeedUpAngle { get; set; } = -2f;
    public float loadindDecreseCof = 20f;

    [SerializeField] private float targetAngle = 270f;

   
    public double actualLoadingSpeed;
    private void Start()
    {
        CanClick = true;
        IsLoadingEnded = false;
        currentAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.eulerAngles.z < 2f && transform.eulerAngles.z > 0f)
        {
            transform.eulerAngles = new Vector3(currentAngle.x, currentAngle.y, 0f);
            CanDecrise = true;
        }

        if (targetAngle > TargetSpeedOfLoading)
        {
            targetAngle += TargetSpeedUp;
        }

        if (currentAngle.z > 245)
        {
            CanDecrise = false;
        }
        if (currentAngle.z < 245f)
        {
            CanDecrise = true;
        }
        float zRotation = Mathf.Clamp(Mathf.LerpAngle(currentAngle.z, targetAngle, Time.deltaTime), 0f, 270f);
        currentAngle = new Vector3(currentAngle.x, currentAngle.y,
            zRotation);
        //при достижеии определенного значения скорость начинает падать
        float maxSpeedWithoutDecr = 245f;
        if (CanDecrise && transform.eulerAngles.z < maxSpeedWithoutDecr)
        {
            LoadingDecrease();
        }

        if (transform.eulerAngles.z > maxSpeedWithoutDecr)
        {
            TargetSpeedOfLoading = 250f;
            TargetSpeedUp = -2f;
        }

        if (currentAngle.z < 270 && currentAngle.z > 0)
        {
            transform.eulerAngles = currentAngle;
        }

        //Debug.Log("angles: " + transform.eulerAngles.z);


        if (IsLoadingEnded)
        {
            currentAngle = new Vector3(currentAngle.x, currentAngle.y,
                Mathf.LerpAngle(currentAngle.z, targetAngle, Time.deltaTime));

            transform.eulerAngles = currentAngle;
        }
        Debug.Log("currentangle: " + currentAngle.z);

        float maxSpeed = 100f;
        float speedometrAngles = 270;

        actualLoadingSpeed = Math.Round(100 - transform.eulerAngles.z * maxSpeed / speedometrAngles, 2, MidpointRounding.ToEven);
        //Math.Ceiling(100 - transform.eulerAngles.z * maxSpeed / speedometrAngles);
        //Debug.Log("actualLoadingSpeed: " + actualLoadingSpeed);
    }



    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        if (CanClick) 
        {
            TargetSpeedUp += SpeedUpAngle;
            targetAngle += SpeedUpAngle;
        }

        //targetAngle = currentAngle.z + Speed;
    }

    private void LoadingDecrease()
    {
        Debug.Log("LoadingDecrease");

       TargetSpeedUp -= SpeedUpAngle/ loadindDecreseCof;
       targetAngle -= SpeedUpAngle/ loadindDecreseCof;


    }

    public void StopLoading()
    {
        targetAngle = 270f;
        IsLoadingEnded = true;

    }

    public void IncreaseAngle(float angle)
    {
        targetAngle += angle;
    }

}
