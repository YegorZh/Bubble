using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMediator : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] GameObject _bubbleDeathPrefab;

    void OnEnable()
    {
      _health.onDeath += HandleDeath;
    }

    void OnDisable()
    {
      _health.onDeath -= HandleDeath;
    }

    void HandleDeath()
    {
      var bubbleDeath = Instantiate(_bubbleDeathPrefab, transform);
      bubbleDeath.transform.parent = null;
      Destroy(gameObject);
    } 
}
