using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    public event Action<Collider2D> onCollisionEnter;
    public event Action<Collider2D> onCollisionStay;
    public event Action<Collider2D> onCollisionExit;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        onCollisionEnter?.Invoke(other.collider);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        onCollisionExit?.Invoke(other.collider);
    }
    
    void OnCollisionStay2D(Collision2D other)
    {
        onCollisionStay?.Invoke(other.collider);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        onCollisionEnter?.Invoke(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onCollisionExit?.Invoke(other);
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        onCollisionStay?.Invoke(other);
    }
}
