using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public int slotNumber;
    public int points;

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"{other.name} entered slot {name}");
        Debug.Log($"Entered slot {slotNumber} and got {points} points");
    }
}
