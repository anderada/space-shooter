using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public float scale;
    public Vector2 location;
    public Vector2 worldSize;
    public Transform playerTransform;
    public Transform enemyTransform;
    public List<Transform> asteroidTransforms;
    public float asteroidSize;
    public float playerSize;

    // Update is called once per frame
    void Update()
    {
        drawBorder();
        drawPlayer(playerTransform, Color.cyan);
        drawPlayer(enemyTransform, Color.red);
        drawAsteroids();
    }

    public void drawBorder(){
        Vector2 corner0 = new Vector2(location.x - ((worldSize.x/2f) * scale), location.y - ((worldSize.y/2f) * scale));
        Vector2 corner1 = new Vector2(location.x + ((worldSize.x/2f) * scale), location.y - ((worldSize.y/2f) * scale));
        Vector2 corner2 = new Vector2(location.x - ((worldSize.x/2f) * scale), location.y + ((worldSize.y/2f) * scale));
        Vector2 corner3 = new Vector2(location.x + ((worldSize.x/2f) * scale), location.y + ((worldSize.y/2f) * scale));
        Debug.DrawLine(corner0, corner1, Color.white);
        Debug.DrawLine(corner0, corner2, Color.white);
        Debug.DrawLine(corner2, corner3, Color.white);
        Debug.DrawLine(corner1, corner3, Color.white);
    }

    public void drawPlayer(Transform ship, Color col){
        Vector2 playerPosition = ship.position;
        float theta = ship.eulerAngles.z;
        theta += 90;
        playerPosition *= scale;
        Vector2 corner0 = location + playerPosition + (new Vector2(Mathf.Cos(theta * Mathf.Deg2Rad), Mathf.Sin(theta * Mathf.Deg2Rad)) * playerSize);
        theta += 140;
        Vector2 corner1 = location + playerPosition + (new Vector2(Mathf.Cos(theta * Mathf.Deg2Rad), Mathf.Sin(theta * Mathf.Deg2Rad)) * playerSize);
        theta += 80;
        Vector2 corner2 = location + playerPosition + (new Vector2(Mathf.Cos(theta * Mathf.Deg2Rad), Mathf.Sin(theta * Mathf.Deg2Rad)) * playerSize);

        Debug.DrawLine(corner0, corner1, col);
        Debug.DrawLine(corner1, corner2, col);
        Debug.DrawLine(corner0, corner2, col);
    }

    public void drawAsteroids(){
        foreach(Transform asteroid in asteroidTransforms){
            DrawCircle(asteroidSize, 3, (asteroid.position * scale) + new Vector3(location.x, location.y));
        }
    }

    public void DrawCircle(float radius, int circlePoints, Vector3 circleCentre){
        for(int i = 0; i < circlePoints; i++){
            Vector3 c1 = new Vector3(Mathf.Cos((Mathf.PI * 2 / circlePoints) * i) * radius, Mathf.Sin((Mathf.PI * 2 / circlePoints) * i) * radius);
            Vector3 c2 = new Vector3(Mathf.Cos((Mathf.PI * 2 / circlePoints) * (i+1))  * radius, Mathf.Sin((Mathf.PI * 2 / circlePoints) * (i+1)) * radius);
            Debug.DrawLine(circleCentre + c1, circleCentre + c2, Color.white);
        }
    }
}
