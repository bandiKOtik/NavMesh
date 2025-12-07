using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InputExample : MonoBehaviour
{
    [SerializeField] private bool isEnabled;

    [SerializeField] private Character _playerCharacter;
    [SerializeField] private ParticleSystem _pointParticle;
    [SerializeField] private float _minDistance = 1f;
    [SerializeField] private float _rayCastDistance = 99f;

    private NavMeshPath _pathToTarget;

    private CompositController _controller;
    private IDirectionMoveable _moveable;
    private IDirectionRotateable _rotateable;

    private void Awake()
    {
        _moveable = _playerCharacter.GetComponent<IDirectionMoveable>();
        _rotateable = _playerCharacter.GetComponent<IDirectionRotateable>();
        _pathToTarget = new NavMeshPath();

        _controller = new CompositController(
            new PointerMoveableController(_moveable, _pointParticle, _minDistance, _rayCastDistance, _pathToTarget),
            new PointerRotateableController(_rotateable, _minDistance, _pathToTarget));

        isEnabled = true;
    }

    private void Update()
    {
        if (isEnabled)
            _controller.Enable();
        else
            _controller.Disable();

        if (_playerCharacter.CurrentHealth <= 0)
            _controller.Disable();

            _controller.Update(Time.deltaTime);

        Restart();
    }

    private void Restart()
    {
        // Testovoe (debajnoe)
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
