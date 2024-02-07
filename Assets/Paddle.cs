using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float unitsPerSecond = 2100000f;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    private void FixedUpdate() {
        // Player 1
        if(this.CompareTag("Player1")) {
            float value1 = Input.GetAxis("Player1");
            Vector3 force1 = Vector3.up * value1; // * unitsPerSecond * Time.deltaTime;

            Rigidbody rb1 = GetComponent<Rigidbody>();
            rb1.AddForce(force1, ForceMode.Force);
        }
        
        // Player 2
        if(this.CompareTag("Player2")) {
            float value2 = Input.GetAxis("Player2");
            Vector3 force2 = Vector3.up * value2; // * unitsPerSecond * Time.deltaTime;
    
            Rigidbody rb2 = GetComponent<Rigidbody>();
            rb2.AddForce(force2, ForceMode.Force);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log($"we hit {collision.gameObject.name}");
        
        // get reference to paddle collider
        BoxCollider bc = GetComponent<BoxCollider>();
        // Get Bounds
        Bounds bounds = bc.bounds;
        float maxY = bounds.max.y;
        float minY = bounds.min.y;
        Debug.Log($"maxY = {maxY}, minY = {minY}");
        Debug.Log($"x pos of ball is {collision.transform.position.x}");
        
        // Collision Point
        Vector3 collisionPoint = Vector3.zero;
        foreach(ContactPoint contact in collision.contacts) {
            collisionPoint += contact.point;
        }
        collisionPoint /= collision.contacts.Length;
        Debug.Log($"Collision point: {collisionPoint}");
        
        // Collision Point Relative To Paddle Position, would like to get degrees relative to origin
        double degrees =  Math.Cos(0.5 / collisionPoint.y);
        
        // Bounce Direction
        Quaternion rotation = Quaternion.Euler(0f, 0f, 60f);
        Vector3 bounceDirection = rotation * Vector3.up;
        
        // Bounce
        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 1000f, ForceMode.Force);
    }
}