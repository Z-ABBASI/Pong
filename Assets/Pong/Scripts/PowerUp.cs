using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collider = UnityEngine.Collider;
using MonoBehaviour = UnityEngine.MonoBehaviour;

public class PowerUp : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Speed"))
        {
            gameManager.OnSpeedTrigger();
            Destroy(gameObject);
        }
        
        if (this.CompareTag("Size"))
        {
            gameManager.OnSizeTrigger();
            Destroy(gameObject);
        }
    }
}