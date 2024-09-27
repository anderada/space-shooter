using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector2 velocity;

    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement(){
        velocity = player.position - transform.position;
        velocity = velocity.normalized;
        velocity = velocity * speed;
        transform.Translate(velocity * Time.deltaTime);
    }

}
