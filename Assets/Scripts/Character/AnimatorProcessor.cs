using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorProcessor
{
    private Animator _animator;
    private Character _character;

    private int _healthHash = Animator.StringToHash("Health");
    private int _velocityHash = Animator.StringToHash("Velocity");
    private int _damageHash = Animator.StringToHash("Damage");
    private int _deadHash = Animator.StringToHash("Dead");

    private const string _injuredLayerName = "InjuredLayer";
    private readonly int _injuredLayerIndex;

    private float _tempHealth;
    private IDirectionMoveable _mover;

    public AnimatorProcessor(Animator animator, Character character)
    {
        _animator = animator;
        _character = character;
        _tempHealth = _character.MaxHealth;
        _mover = character.GetComponent<IDirectionMoveable>();
        _injuredLayerIndex = _animator.GetLayerIndex(_injuredLayerName);
    }

    public void Update()
    {
        float health = _character.CurrentHealth;
        float maxHealth = _character.MaxHealth;
        float speed = _mover.CurrentVelocity.magnitude;

        _animator.SetFloat(_healthHash, health);
        _animator.SetFloat(_velocityHash, speed);

        if (health <= 0)
        {
            _animator.SetBool(_deadHash, true);
            _animator.SetLayerWeight(_injuredLayerIndex, 0);
            return;
        }

        _animator.SetLayerWeight(_injuredLayerIndex, MathUtils.MirroredValueNormalize(health, maxHealth));

        if (health < _tempHealth)
            _animator.SetTrigger(_damageHash);

        _tempHealth = health;
    }
}
