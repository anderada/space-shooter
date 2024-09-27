using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigExcercise : MonoBehaviour
{

    public List<float> angles;
    public float radius;
    int index = 0;
    public Vector2 circlePosition;
    float clock = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if (clock > 5f) {
            for (int i = 0; i < angles.Count; i++) {
                angles[i] += Random.Range(0, 360);
            }
            clock = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            index++;
            index %= angles.Count;
        }
        Vector2 line = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angles[index]), Mathf.Sin(Mathf.Deg2Rad * angles[index]));
        line *= radius;
        Debug.DrawLine(circlePosition, circlePosition + line);
    }
}
