using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLogic : MonoBehaviour
{
    [SerializeField] Sprite _inactiveSprite;
    [SerializeField] Sprite _activeSprite;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] ColliderHandler _colliderHandler;
    static List<CheckpointLogic> _checkpoints = new();
    GameManager _gameManager;
    bool _isActive;

    public void ClearCheckpoints()
    {
        _checkpoints = new();
    }

    void OnEnable()
    {
        _colliderHandler.onCollisionEnter += HandleCollide;
    }

    void HandleCollide(Collider2D obj)
    {
        if(!_isActive) BecomeActive();;
    }

    void Awake()
    {
        if (!_checkpoints.Contains(this)) _checkpoints.Add(this);
        if (_gameManager == null) _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void BecomeActive()
    {
        _checkpoints.Find(checkpoint => checkpoint._isActive)?.BecomeInactive();
        _isActive = true;
        _spriteRenderer.sprite = _activeSprite;
        _gameManager.SetActiveCheckpointTransform(transform);
    }

    void BecomeInactive()
    {
        _isActive = false;
        _spriteRenderer.sprite = _inactiveSprite;
    }
}
