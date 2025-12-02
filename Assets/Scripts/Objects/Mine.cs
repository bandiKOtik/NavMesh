using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timeBeforeExplode = 3f;
    [SerializeField] private float _mineRadius = 5f;
    [SerializeField] private float _damage = 25f;
    [SerializeField] private SphereCollider _detectorCollider;
    [SerializeField] private ParticleSystem _explosionParticle;

    private Animator _animator;
    private int _activateHash = Animator.StringToHash("Activate");

    private void Awake()
    {
        _detectorCollider.radius = _mineRadius;

        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character _character))
            StartCoroutine(ActivateMine());
    }

    private IEnumerator ActivateMine()
    {
        Activate();

        yield return new WaitForSeconds(_timeBeforeExplode);

        Explode();

        Destroy(gameObject);
    }

    private void Activate()
    {
        _animator.SetTrigger(_activateHash);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _mineRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Character>(out Character character))
                character.DealDamage(_damage);
        }

        if (_explosionParticle != null)
            Instantiate(_explosionParticle, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, .25f);

        Gizmos.DrawSphere(transform.position, _mineRadius);
    }
}
