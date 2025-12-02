using UnityEngine;

public class DirectionalRotator
{
    private Transform _transform;
    private float _rotateSpeed;
    private Vector3 _currentDirection;
    public Quaternion CurrentRotation { get; private set; }

    public DirectionalRotator(Transform transform, float rotateSpeed)
    {
        _transform = transform;
        _rotateSpeed = rotateSpeed;
    }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        CurrentRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotateSpeed * deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, CurrentRotation, step);
    }
}
