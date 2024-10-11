using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotProd : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;
    Vector2 redVector;
    Vector2 blueVector;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        redVector = new Vector2(Mathf.Cos(redAngle * Mathf.Deg2Rad), Mathf.Sin(redAngle * Mathf.Deg2Rad));
        blueVector = new Vector2(Mathf.Cos(blueAngle * Mathf.Deg2Rad), Mathf.Sin(blueAngle * Mathf.Deg2Rad));

        redVector.Normalize();
        blueVector.Normalize();

        Debug.DrawLine(Vector2.zero, redVector, Color.red);
        Debug.DrawLine(Vector2.zero, blueVector, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space)) {
            float dotProd = Vector2.Dot(redVector, blueVector);
            Debug.Log(dotProd);
        }
    }
}
