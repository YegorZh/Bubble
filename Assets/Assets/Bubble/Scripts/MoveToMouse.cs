using System;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _speedScale;
    [SerializeField] float _maxSpeed;
    Transform _cachedTransform;
    Camera _cachedCamera;
    public bool CanMove = true;
    
    void FixedUpdate()
    {
        ProcessMovement();
    }
    
    void ProcessMovement()
    {
        if (!CanMove) return;
        _cachedTransform ??= transform;
        _cachedCamera ??= Camera.main;
        var targetPos = _cachedCamera.ScreenToWorldPoint(Input.mousePosition);
        var baseVelocity = targetPos - _cachedTransform.position;
        var velocityX = Mathf.Min(Mathf.Abs(baseVelocity.x * _speedScale), _maxSpeed) * Mathf.Sign(baseVelocity.x);
        var velocityY = Mathf.Min(Mathf.Abs(baseVelocity.y * _speedScale), _maxSpeed) * Mathf.Sign(baseVelocity.y);
        _rigidbody2D.velocity = new (velocityX, velocityY);
    }
}
