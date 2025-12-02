using UnityEngine;

public interface IDirectionRotateable
{
    Quaternion CurrentRotation { get; }
    void SetRotationDirection(Vector3 direction);
}
