using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _playerCharacter;
    [SerializeField] private ParticleSystem _pointParticle;
    [SerializeField] private float _minDistance = 0.1f;
    private NavMeshPath _pathToTarget;

    private CompositController _controller;

    private void Awake()
    {
        _pathToTarget = new NavMeshPath();

        _controller = new CompositController(
            new PointerMoveableController(_playerCharacter.GetComponent<IDirectionMoveable>(), _pointParticle, _minDistance, _pathToTarget),
            new PlayerDirectionalRotateableController(_playerCharacter));

        //_keyboardController = new PlayerPointerController(_keyboardInputCharacter, null);

        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    if (_pathToTarget.status != NavMeshPathStatus.PathInvalid)
    //        foreach (Vector3 corner in _pathToTarget.corners)
    //            Gizmos.DrawSphere(corner, 0.3f);
    //}
}
