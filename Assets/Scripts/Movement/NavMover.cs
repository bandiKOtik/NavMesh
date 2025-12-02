using UnityEngine;
using UnityEngine.AI;

public class NavMover
{
    private NavMeshAgent _agent;
    private float _movementSpeed;
    protected Vector3 _currentDirection;
    public Vector3 CurrentVelocity { get; private set; }

    public NavMover(NavMeshAgent agent, float movementSpeed)
    {
        _agent = agent;
        _movementSpeed = movementSpeed;
    }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        CurrentVelocity = _currentDirection.normalized * _movementSpeed * deltaTime;

        _agent.Move(CurrentVelocity);
    }
}
