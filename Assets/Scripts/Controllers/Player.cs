using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    Vector2 direction;
    public float maxSpeed = 5;
    public float accTime = 1;
    public float accClock = 0;
    public float decTime = 1;

    void Start(){
        direction = new Vector2(0,0);
    }

    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement(){
        if(Input.GetKey(KeyCode.UpArrow)){
            direction.y = 1;
            direction.x = 0;
            accClock = Mathf.Min(accClock + Time.deltaTime, accTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            direction.y = -1;
            direction.x = 0;
            accClock = Mathf.Min(accClock + Time.deltaTime, accTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            direction.x = 1;
            direction.y = 0;
            accClock = Mathf.Min(accClock + Time.deltaTime, accTime);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            direction.x = -1;
            direction.y = 0;
            accClock = Mathf.Min(accClock + Time.deltaTime, accTime);
        }
        else{
            accClock = Mathf.Max(accClock - Time.deltaTime, 0);
            transform.Translate(direction * Mathf.Lerp(0, maxSpeed, accClock/decTime) * Time.deltaTime);
            return;
        }
        transform.Translate(direction * Mathf.Lerp(0, maxSpeed, accClock/accTime) * Time.deltaTime);
    }

}
