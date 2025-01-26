using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDead : MonoBehaviour
{
    // Called via animation event
    public void OnDead()
    {
        Destroy(gameObject);
    }
}
