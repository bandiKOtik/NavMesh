using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation
{
    private Animator _animator;
    private Character _character;

    private int _healthHash = Animator.StringToHash("Health");
    private int _velocityHash = Animator.StringToHash("Velocity");
    private int _damageHash = Animator.StringToHash("Damage");
    private int _deadHash = Animator.StringToHash("Dead");

    private float _tempHealth;

    public CharacterAnimation(Animator animator, Character character)
    {
        _animator = animator;
        _character = character;
        _tempHealth = _character.MaxHealth;
    }

    public void Update(float health, float velociy)
    {
        if (health <= 0)
            _animator.SetBool(_deadHash, true);

        _animator.SetFloat(_healthHash, health);
        _animator.SetFloat(_velocityHash, velociy);

        if (health < _tempHealth)
            _animator.SetTrigger(_damageHash);

        _tempHealth = health;
    }
}
