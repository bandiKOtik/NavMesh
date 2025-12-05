using UnityEngine;

public class Character : MonoBehaviour, IDirectionMoveable, IDirectionRotateable, IDamageable
{
    private CharacterAnimation _characterAnimation;

    private DirectionalMover _mover;
    private DirectionalRotator _rotator;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;
    public Vector3 Position => transform.position;
    public float MaxHealth => 100f;
    float IDamageable.Health { get; set; }

    private float _currentHealth;

    private void Awake()
    {
        Character character = GetComponent<Character>();

        _characterAnimation = new CharacterAnimation(GetComponent<Animator>(), character);

        _mover = new DirectionalMover(GetComponent<CharacterController>(), _movementSpeed);
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
    public void Heal(float amout) => _currentHealth += amout;
    public void DealDamage(float amount) => _currentHealth -= amount;
}
