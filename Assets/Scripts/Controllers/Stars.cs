using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    float drawClock = 0;

    // Update is called once per frame
    void Update()
    {
        DrawConstelation();
    }

    public void DrawConstelation(){
        drawClock += Time.deltaTime;
        int i = 0;
        foreach (Transform star in starTransforms){
            if(i == starTransforms.Count - 1) continue;
            Vector3 nextStar = starTransforms[i+1].position;
            Vector3 line = nextStar - star.position;
            float distanceToNext = line.magnitude;
            line = line.normalized;
            line = line * Mathf.Clamp(((drawClock - (i * drawingTime)) / drawingTime) * distanceToNext, 0, distanceToNext);
            Debug.DrawLine(star.position, star.position + line);
            i++;
        }
        if(drawClock >= starTransforms.Count * drawingTime){
            drawClock = 0;
        }
    }
}
