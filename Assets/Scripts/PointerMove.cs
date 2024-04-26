using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PointerMove : MonoBehaviour
{
    public Transform pointer;
    public Transform pointerStart;
    public Transform pointerEnd;

    private float laju;
    int direction = 1;

    private int FishType;

    public int GetFishType()
    {
        return FishType;
    }

    private void Start()
    {
        FishType = Random.Range(0, 4);
        Debug.Log("FishType FishingSpot = " + FishType);

        switch (FishType)
        {
            case 0:
                laju = 1.0f;
                break;
            case 1:
                laju = 1.6f;
                break;
            case 2:
                laju= 1.9f; 
                break;
            case 3:
                laju = 2.2f;
                break; 
            default:
                laju = 2.5f;
                break;
        }
    }

    private void Update()
    {
        
        Vector2 target = currentMovementTarget();
        
        pointer.position = Vector2.MoveTowards(pointer.position, target, laju);

        float jarak = (target - (Vector2)pointer.position).magnitude;

        if( jarak <= 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return pointerStart.position;
        }
        else
        {
            return pointerEnd.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (pointer != null && pointerStart != null && pointerEnd != null)
        {
            Gizmos.DrawLine(pointer.transform.position, pointerStart.position);
            Gizmos.DrawLine(pointer.transform.position, pointerEnd.position);
        }
    }
}
