using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSystem : MonoBehaviour
{
    public Action onGoalReached;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) onGoalReached?.Invoke();
    }
}
