using System.Collections;
using System.Collections.Generic;
using Assets.Hazards.Tiles;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public enum LoopMoveState
{
    Start = 0,
    End = 1
}

public class LoopMove : BaseTileMovement
{
    LoopMoveState _state = LoopMoveState.Start;
    
    IEnumerator ToggleStateChange()
    {
        for(;;)
        {
            Rigidbody2D.velocity = Vector2.zero;
            if (_state == LoopMoveState.Start) yield return new WaitForSeconds(TileMovementSettings.StartDelay);
            else yield return new WaitForSeconds(TileMovementSettings.EndDelay);
            Rigidbody2D.velocity = new Vector2(
                TileMovementSettings.Speed.x * TileMovementSettings.MoveDirection.y, 
                TileMovementSettings.Speed.y * TileMovementSettings.MoveDirection.x);
            
            TileMovementSettings.MoveDirection *= -1;
            yield return new WaitForSeconds(TileMovementSettings.MoveDuration);
            _state = (LoopMoveState)(((int)_state + 1) % 2);
        }
    }
    
    void Start()
    {
        StartCoroutine(ToggleStateChange());
    }
}
