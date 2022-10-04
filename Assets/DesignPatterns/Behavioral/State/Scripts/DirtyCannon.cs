using System.Collections;
using TMPro;
using UnityEngine;

public enum DirtyCannonState : byte
{
    Idle = 0,
    Attacking,
    Realoading,
    Destroyed,
    Damaged
}

public class DirtyCannon : MonoBehaviour
{
    [SerializeField] private TMP_Text _stateText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _bulletText;
    [field: SerializeField] public Transform Target { get; set; }
    [SerializeField] private Transform _turret;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ParticleSystem _fireVfx;

    private DirtyCannonState _state;

    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            _healthText.text = $"Health: {value}";
            _health = value;
        }
    }

    private int _bulletCount;
    public int BulletCount
    {
        get => _bulletCount;
        set
        {
            _bulletText.text = $"Bullets: {value}";
            _bulletCount = value;
        }
    }

    private int _maxHealth = 3;
    private int _maxBullets = 5;
    private float _bulletSpeed = 10f;
    private float _timeBetweenShooting = 1f;
    private float _timeBetweenReloadingBullets = .5f;

    private Coroutine _attackCoroutine;
    private Coroutine _reloadCoroutine;

    private void Awake()
    {
        Health = _maxHealth;
        BulletCount = _maxBullets;
        _state = DirtyCannonState.Idle;
    }

    private void Update()
    {
        if (Target == null || (_state != DirtyCannonState.Attacking && _state != DirtyCannonState.Idle)) return;

        _turret.LookAt(Target.position);
    }

    public void Attack()
    {
        if (_state == DirtyCannonState.Idle)
        {
            _state = DirtyCannonState.Attacking;
            if (_attackCoroutine != null) StopCoroutine(_attackCoroutine);
            _attackCoroutine = StartCoroutine(ShootBullets());
        }
        else if (_state == DirtyCannonState.Realoading)
        {
            if (_reloadCoroutine != null) StopCoroutine(_reloadCoroutine);
            _state = DirtyCannonState.Attacking;
            if (_attackCoroutine != null) StopCoroutine(_attackCoroutine);
            _attackCoroutine = StartCoroutine(ShootBullets());
        }
    }

    public void Stop()
    {
        if (_state == DirtyCannonState.Attacking)
        {
            StopCoroutine(_attackCoroutine);
            _state = DirtyCannonState.Idle;
        }
        else if (_state == DirtyCannonState.Realoading)
        {
            StopCoroutine(_reloadCoroutine);
            _state = DirtyCannonState.Idle;
        }
    }

    public void Damage()
    {
        Health = Health == 0 ? Health : Health - 1;

        if (_state == DirtyCannonState.Attacking)
        {
            if (_attackCoroutine != null) StopCoroutine(_attackCoroutine);
        }
        if (_state == DirtyCannonState.Realoading)
        {
            if (_reloadCoroutine != null) StopCoroutine(_reloadCoroutine);
        }

        if (_state != DirtyCannonState.Destroyed)
        {
            _state = Health == 0 ? DirtyCannonState.Destroyed : DirtyCannonState.Damaged;
        }
    }

    public void Repair()
    {
        if (_state != DirtyCannonState.Damaged)
        {
            Debug.Log("Nothing to repair");
            return;
        }

        Health = _maxHealth;
        _state = DirtyCannonState.Idle;
    }

    public void Destroy()
    {
        if (_state == DirtyCannonState.Attacking)
        {
            if (_attackCoroutine != null) StopCoroutine(_attackCoroutine);
        }
        if (_state == DirtyCannonState.Realoading)
        {
            if (_reloadCoroutine != null) StopCoroutine(_reloadCoroutine);
        }

        Health = 0;
        _state = DirtyCannonState.Destroyed;
        _turret.gameObject.SetActive(false);
    }

    public void Revive()
    {
        if(_state == DirtyCannonState.Destroyed)
        {
            Health = _maxHealth;
            _state = DirtyCannonState.Idle;
            _turret.gameObject.SetActive(true);
        }
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            if (BulletCount == 0)
            {
                _state = DirtyCannonState.Realoading;
                _reloadCoroutine = StartCoroutine(ReloadBullets());
                yield break;
            }
            BulletCount--;
            var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation).GetComponent<Rigidbody>();
            bullet.velocity = _shootPoint.forward * _bulletSpeed;
            _fireVfx.Play();
            yield return new WaitForSeconds(_timeBetweenShooting);
        }
    }

    private IEnumerator ReloadBullets()
    {
        for (int i = BulletCount; i < _maxBullets; i++)
        {
            BulletCount++;
            yield return new WaitForSeconds(_timeBetweenReloadingBullets);
        }
        Attack();
    }
}
