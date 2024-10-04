using System.Collections;
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
    public float circleRadius = 2;
    public int powerupPoints = 5;
    public float powerupRadius = 3;

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
        DrawCircle(circleRadius, circlePoints);
        if(Input.GetKeyDown(KeyCode.P)){
            SpawnPowerups(powerupRadius, powerupPoints);
        }
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
