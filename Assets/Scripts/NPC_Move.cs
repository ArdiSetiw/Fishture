using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPositionTracker : MonoBehaviour
{
    public Animator animator;
    public Transform trackedObject;
    public float positionThreshold = 0.1f;

    private Vector3 lastPosition;

    void Start()
    {
        // Initialize lastPosition to current position of the tracked object
        lastPosition = trackedObject.position;
    }

    void Update()
    {
        // Calculate movement since last frame
        Vector2 movement = trackedObject.position - lastPosition;

        // Check if movement exceeds the threshold in either direction
        if (Mathf.Abs(movement.x) > positionThreshold || Mathf.Abs(movement.y) > positionThreshold)
        {
            
            // Object has moved, update the animator parameters
            UpdateAnimatorParameters(movement);

            // Update lastPosition to current position of the tracked object
            lastPosition = trackedObject.position;
        }
    }

    void UpdateAnimatorParameters(Vector2 movement)
    {
        // Here you can set the animator parameters based on the object's movement
        // For example, let's say you have float parameters called "HorizontalDirection" and "VerticalDirection"
        // You can set them to -1 for left/down movement and 1 for right/up movement
        float horizontalDirection = Mathf.Sign(movement.x);
        float verticalDirection = Mathf.Sign(movement.y);
        Debug.Log(horizontalDirection);
        animator.SetFloat("Horizontal", horizontalDirection);
        animator.SetFloat("Vertical", verticalDirection);
    }
}
