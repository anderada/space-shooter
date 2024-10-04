using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float theta = 0;
    public float speed = 0.01f;
    public float radius = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target){
        theta += speed * Time.deltaTime;
        theta %= Mathf.PI * 2;
        transform.position = target.position + new Vector3(Mathf.Cos(theta) * radius, Mathf.Sin(theta) * radius);
    }
}
