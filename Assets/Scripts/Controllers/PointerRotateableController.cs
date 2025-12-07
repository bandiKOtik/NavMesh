using UnityEngine;
using UnityEngine.AI;

public class PointerRotateableController : Controller
{
    private const int leftMouseButtonIndex = 0;
    private Vector3 _currentRotationTarget;

    private IDirectionRotateable _rotateable;
    private readonly float _minDistanceToTarget = .1f;
    private NavMeshPath _path;

    public PointerRotateableController(IDirectionRotateable rotateable, float minDistanceToTarget, NavMeshPath path)
    {
        _rotateable = rotateable;
        _minDistanceToTarget = minDistanceToTarget;
        _path = path;
        _currentRotationTarget = rotateable.Position;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (IsEnoughCornersInPath(_path))
            _currentRotationTarget = _path.corners[_path.corners.Length - 1];

        ProcessRotation(_currentRotationTarget);
    }

    private void ProcessRotation(Vector3 targetPosition)
    {
        if (NavMesh.CalculatePath(_rotateable.Position, targetPosition, NavMesh.AllAreas, _path))
        {
            if (IsEnoughCornersInPath(_path))
            {
                Vector3 currentTarget = _path.corners[1] - _path.corners[0];

                _rotateable.SetRotationDirection(currentTarget);
            }
        }
    }

    private bool IsEnoughCornersInPath(NavMeshPath path) => path.corners.Length > 1;
}
