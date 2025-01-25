using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    int _currentHealth;

    public event Action<bool> onDeath;

    public void ApplyDamage(int damage, bool respawnAtCheckpoint = true)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        if(_currentHealth == 0) onDeath?.Invoke(respawnAtCheckpoint);
    }
}
