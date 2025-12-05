using UnityEngine;

public interface IDirectionMoveable : ITransformPosition
{
    Vector3 CurrentVelocity { get; }
    void SetMoveDirection(Vector3 direction);
}
