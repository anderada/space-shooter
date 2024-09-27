using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    Vector2 velocity;
    public float maxSpeed = 5;
    public float accTime = 1;
    public float decTime = 1;

    void Start(){
        velocity = new Vector2(0,0);
    }

    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement(){

        velocity.x += Input.GetAxis("Horizontal") * Time.deltaTime/accTime;
        velocity.y += Input.GetAxis("Vertical") * Time.deltaTime / accTime;

        if (Input.GetAxis("Vertical") == 0)
        {
            if(velocity.y > 0)
                velocity.y -= Time.deltaTime / decTime;
            else
                velocity.y += Time.deltaTime / decTime;

        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (velocity.x > 0)
                velocity.x -= Time.deltaTime / decTime;
            else
                velocity.x += Time.deltaTime / decTime;

        }

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);

        transform.Translate(velocity * Time.deltaTime);
    }

}
