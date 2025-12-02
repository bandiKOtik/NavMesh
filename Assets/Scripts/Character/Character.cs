using UnityEngine;

public class Character : MonoBehaviour, IDirectionMoveable, IDirectionRotateable
{
    private CharacterAnimation _characterAnimation;

    private CharacterMover _mover;
    private DirectionalRotator _rotator;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private ParticleSystem _pointer;
    public float MaxHealth => 100f;
    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    private float _currentHealth;

    private void Awake()
    {
        Character character = GetComponent<Character>();

        _characterAnimation = new CharacterAnimation(GetComponent<Animator>(), character);

        _mover = new CharacterMover(GetComponent<CharacterController>(), _movementSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);

        _currentHealth = MaxHealth;
    }

    public void Update()
    {
        _characterAnimation.Update(_currentHealth, CurrentVelocity.magnitude);

        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);
    public void SetRotationDirection(Vector3 direction) => _rotator.SetInputDirection(direction);
    public void DealDamage(float amount) => _currentHealth -= amount;
}
