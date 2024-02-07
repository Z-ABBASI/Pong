using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Manager.updateScore(other);
        Destroy(this);
    }
}