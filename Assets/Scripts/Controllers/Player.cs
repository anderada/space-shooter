﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;
    public int circlePoints = 7;
    public float circleRadius = 2f;
    public int powerupPoints = 5;
    public float powerupRadius = 3f;

    public Vector2 velocity;
    public float maxSpeed = 5f;
    public float accTime = 1f;
    public float decTime = 1f;
    float accPerSec;
    float decPerSec;

    void Start(){
        velocity = new Vector2(0,0);
        accPerSec = maxSpeed / accTime;
        decPerSec = -maxSpeed / decTime;
    }

    void Update()
    {
        PlayerMovement();
        DrawCircle(circleRadius, circlePoints);
        if(Input.GetKeyDown(KeyCode.P)){
            SpawnPowerups(powerupRadius, powerupPoints);
        }
        pointTowardsMouse();
    }

    public void pointTowardsMouse(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDifference = mousePos - transform.position;
        mouseDifference = mouseDifference.normalized;
        Debug.DrawLine(transform.position, mousePos, Color.red);
        float theta = Mathf.Atan2(mouseDifference.y, mouseDifference.x) * Mathf.Rad2Deg;
        theta -= 90;
        transform.eulerAngles = new Vector3(0,0,theta);
    }

    public void PlayerMovement(){

        velocity.x += Input.GetAxis("Horizontal") * accPerSec * Time.deltaTime;
        velocity.y += Input.GetAxis("Vertical") * accPerSec * Time.deltaTime;

        if (Input.GetAxis("Vertical") == 0)
        {
            if(velocity.y > 0.00001f)
                velocity.y += decPerSec * Time.deltaTime;
            else if(velocity.y < -0.00001f)
                velocity.y -= decPerSec * Time.deltaTime;
            else
                velocity.y = 0f;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            if(velocity.x > 0.00001f)
                velocity.x += decPerSec * Time.deltaTime;
            else if(velocity.x < -0.00001f)
                velocity.x -= decPerSec * Time.deltaTime;
            else
                velocity.x = 0f;
        }

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);

        transform.Translate(velocity);
    }

    public void DrawCircle(float radius, int circlePoints){
        Color circleColor;
        if((enemyTransform.position - transform.position).magnitude < radius)
            circleColor = Color.red;
        else
            circleColor = Color.green;

        for(int i = 0; i < circlePoints; i++){
            Vector3 c1 = new Vector3(Mathf.Cos((Mathf.PI * 2 / circlePoints) * i ) * radius, Mathf.Sin((Mathf.PI * 2 / circlePoints) * i) * radius);
            Vector3 c2 = new Vector3(Mathf.Cos((Mathf.PI * 2 / circlePoints) * (i+1))  * radius, Mathf.Sin((Mathf.PI * 2 / circlePoints) * (i+1)) * radius);
            Debug.DrawLine(transform.position + c1, transform.position + c2, circleColor);
        }

    }

    public void SpawnPowerups(float radius, int circlePoints){
        for(int i = 0; i < circlePoints; i++){
            Vector3 c = new Vector3(Mathf.Cos((Mathf.PI * 2 / circlePoints) * i ) * radius, Mathf.Sin((Mathf.PI * 2 / circlePoints) * i) * radius);
            Instantiate(powerupPrefab, transform.position + c, Quaternion.identity);
        }
    }

}
