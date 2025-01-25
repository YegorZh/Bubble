using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Hazards.Tiles
{
  [Serializable]
  public class TileMovementSettings
  {
    [field: SerializeField] public Vector2 Speed { get; set; }
    [field: SerializeField] public float MoveDuration { get; set; }
    [field: SerializeField] public float StartDelay { get; set; }
    [field: SerializeField] public float EndDelay { get; set; }
    [field: SerializeField] public Vector2 MoveDirection { get; set; } = new Vector2(1, 1);

    public TileMovementSettings(Vector2 speed, float moveDuration, float startDelay, float endDelay, Vector2 moveDirection)
    {
      Speed = speed;
      MoveDuration = moveDuration;
      MoveDirection = moveDirection;
      StartDelay = startDelay;
      EndDelay = endDelay;
    }

    public TileMovementSettings Clone()
    {
      return new TileMovementSettings(Speed, MoveDuration, StartDelay, EndDelay, MoveDirection);
    }
  }
  
  public class BaseTileMovement : MonoBehaviour
  {
    public TileMovementSettings TileMovementSettings;
    public Rigidbody2D Rigidbody2D;
  }
}
