using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;

    //---------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Goal"))
        {
            gameManager.OnGoalTrigger(this);
        }
        
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