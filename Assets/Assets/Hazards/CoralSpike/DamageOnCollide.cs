using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    [SerializeField] ColliderHandler _colliderHandler;
    [SerializeField] int _damage;
    [SerializeField] float _damageSpeedThreshold = 0;
    
    void OnEnable()
    {
        _colliderHandler.onCollisionEnter += HandleOnCollisionEnter;
    }
    
    void OnDisable()
    {
        _colliderHandler.onCollisionEnter -= HandleOnCollisionEnter;
    }

    void HandleOnCollisionEnter(Collider2D obj)
    {
        var targetGameObject = obj.gameObject;
        var health = targetGameObject.GetComponentInParent<Health>();
        if (!health) return;
        
        if (_damageSpeedThreshold > 0)
        {
            var targetRigidbody = targetGameObject.gameObject.GetComponentInParent<Rigidbody2D>();
            if (targetRigidbody.velocity.magnitude <= _damageSpeedThreshold) return;
        }
        else if (_damageSpeedThreshold < 0)
        {
            var targetRigidbody = targetGameObject.gameObject.GetComponentInParent<Rigidbody2D>();
            if (targetRigidbody.velocity.magnitude > _damageSpeedThreshold * -1) return;
        }
        
        health.ApplyDamage(_damage);
    }       
}
