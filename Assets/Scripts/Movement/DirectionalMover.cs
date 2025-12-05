using UnityEngine;

public class DirectionalMover
{
    private CharacterController _characterController;
    private float _movementSpeed;
    protected Vector3 _currentDirection;
    public Vector3 CurrentVelocity { get; private set; }

    public DirectionalMover(CharacterController characterController, float movementSpeed)
    {
        _characterController = characterController;
        _movementSpeed = movementSpeed;
    }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        CurrentVelocity = _currentDirection.normalized * _movementSpeed * deltaTime;

        _characterController.Move(CurrentVelocity);
    }
}
