using UnityEngine;

public interface IDirectionRotateable : ITransformPosition
{
    Quaternion CurrentRotation { get; }
    void SetRotationDirection(Vector3 direction);
}
