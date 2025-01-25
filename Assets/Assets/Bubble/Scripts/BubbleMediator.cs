using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMediator : MonoBehaviour
{
    [SerializeField] Health _health;

    void OnEnable()
    {
      _health.onDeath += HandleDeath;
    }

    void OnDisable()
    {
      _health.onDeath -= HandleDeath;
    }

    void HandleDeath(bool respawnAtCheckpoint)
    {
      Destroy(gameObject);
      if (!respawnAtCheckpoint) return;
      
    } 
}
