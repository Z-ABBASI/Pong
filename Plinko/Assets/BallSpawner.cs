using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 spawnPosition = new Vector3(0, Random.Range(0f, 14f), Random.Range(0f, 14f));// spawnTransform.position;
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
