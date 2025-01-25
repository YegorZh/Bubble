using System;using System.Collections;
using System.Collections.Generic;
using Assets.Hazards.Tiles;
using UnityEngine;

public enum TileMovementType {
    Cycle,
    Loop,
    Idle
}

public class TileSettings : MonoBehaviour
{
    [SerializeField]
    [OnChangedCall("OnTileWidthChange")]
    int _tileWidth = 1;
    [SerializeField] SpriteRenderer _tileSpriteRenderer;
    [SerializeField] BoxCollider2D _tileBoxCollider;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [Header("Movement")]
    [OnChangedCall("OnMovementComponentTypeChange")]
    [SerializeField] TileMovementType _movementType;
    [SerializeField] TileMovementSettings _tileMovementSettings;
    BaseTileMovement _movementComponent;

    // Automatically called by OnChangedCall property
    public void OnTileWidthChange()
    {
        _tileSpriteRenderer.size = new Vector2(_tileWidth, _tileSpriteRenderer.size.y);
        _tileBoxCollider.size = new Vector2(_tileWidth, _tileBoxCollider.size.y);
    }

    // Automatically called by OnChangedCall property
    public void OnMovementComponentTypeChange()
    {
        if (!_movementComponent) return;
        AddMovementComponent();
    }
    
    void OnEnable()
    {
        AddMovementComponent();
    }

    void OnDisable()
    {
        RemoveMovementComponent();
    }

    void RemoveMovementComponent()
    {
        if (_movementComponent) Destroy(_movementComponent);
    }
    
    void AddMovementComponent()
    {
        RemoveMovementComponent();
        
        if(_movementType == TileMovementType.Loop) _movementComponent = gameObject.AddComponent<LoopMove>();
        else if (_movementType == TileMovementType.Cycle) _movementComponent = gameObject.AddComponent<CycleMove>();
        else return;
        
        _movementComponent.TileMovementSettings = _tileMovementSettings.Clone();
        _movementComponent.Rigidbody2D = _rigidbody2D;
    }
}
