using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevelOnCollide : MonoBehaviour
{
    [SerializeField] ColliderHandler _colliderHandler;
    [SerializeField] GameManager _gameManager;

    void OnEnable()
    {
        _colliderHandler.onCollisionEnter += HandleCollisionEnter;
    }
    
    void OnDisable()
    {
        _colliderHandler.onCollisionEnter -= HandleCollisionEnter;
    }

    void HandleCollisionEnter(Collider2D obj)
    {
        if (!obj.transform.root.CompareTag("Player")) return;
        _gameManager.WinLevel();
    }
}
