using UnityEngine;

public interface IDirectionMoveable
{
    Vector3 CurrentVelocity { get; }
    void SetMoveDirection(Vector3 direction);
}
