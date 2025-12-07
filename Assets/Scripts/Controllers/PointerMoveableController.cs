using UnityEngine;
using UnityEngine.AI;

public class PointerMoveableController : Controller
{
    private const int leftMouseButtonIndex = 0;
    private const int groundLayer = 8;
    private Vector3 _currentTargetDestination;

    private IDirectionMoveable _moveable;
    private ParticleSystem _pointerParticle;
    private ParticleSystem _spawnedParticle;

    private readonly float _minDistanceToTarget = .1f;
    private readonly float _rayCastDistance;
    private NavMeshPath _path;

    public PointerMoveableController(
        IDirectionMoveable moveable,
        ParticleSystem pointerParticle,
        float minDistanceToTarget,
        float rayCastDistance,
        NavMeshPath pathToTarget)
    {
        _moveable = moveable;
        _pointerParticle = pointerParticle;
        _minDistanceToTarget = minDistanceToTarget;
        _rayCastDistance = rayCastDistance;
        _path = pathToTarget;
        _currentTargetDestination = _moveable.Position;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        GetInputFromPlayer();

        ProcessMove(_currentTargetDestination);
    }

    private void GetInputFromPlayer()
    {
        if (Input.GetMouseButtonDown(leftMouseButtonIndex))
        {
            Camera camera = Camera.main;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _rayCastDistance, groundLayer))
            {
                Vector3 destination = hit.point;

                if (_spawnedParticle != null)
                    GameObject.Destroy(_spawnedParticle.gameObject);

                _spawnedParticle = GameObject.Instantiate(_pointerParticle, destination, Quaternion.identity);

                _currentTargetDestination = destination;
            }
        }
    }

    private void ProcessMove(Vector3 destinationPosition)
    {
        if (IsTargetReached(_moveable.Position, destinationPosition) == false)
        {
            if (NavMeshUtils.TryGetPath(_moveable.Position, destinationPosition, NavMesh.AllAreas, _path))
                if (IsEnoughCornersInPath(_path))
                {
                    Vector3 currentTarget = _path.corners[1] - _path.corners[0];

                    if (IsTargetReached(_moveable.Position, currentTarget) == false)
                        _moveable.SetMoveDirection(currentTarget);
                }
        }
        else
        {
            _moveable.SetMoveDirection(Vector3.zero);
        }
    }

    private bool IsTargetReached(Vector3 source, Vector3 target) => Vector3.Distance(source, target) <= _minDistanceToTarget;
    private bool IsEnoughCornersInPath(NavMeshPath path) => path.corners.Length > 1;
}
