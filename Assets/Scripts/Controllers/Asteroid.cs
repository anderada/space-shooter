using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        setTarget();        
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement(){
        if((target - transform.position).magnitude <= arrivalDistance){
            setTarget();
        }
        transform.Translate((target - transform.position).normalized * moveSpeed * Time.deltaTime);
    }

    void setTarget(){
        target = new Vector3(Random.Range(transform.position.x - maxFloatDistance, transform.position.x + maxFloatDistance), Random.Range(transform.position.y - maxFloatDistance, transform.position.y + maxFloatDistance));
    }
}
