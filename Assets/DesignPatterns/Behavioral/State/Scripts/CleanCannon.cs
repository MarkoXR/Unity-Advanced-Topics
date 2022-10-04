using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CleanCannon : MonoBehaviour
{
    [SerializeField] private TMP_Text _stateText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _bulletText;
    [field: SerializeField] public Transform Target { get; set; }
    [SerializeField] private Transform _turret;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ParticleSystem _fireVfx;

    public CannonState IdleState { get; set; }
    public CannonState AttackingState { get; set; }
    public CannonState ReloadingState { get; set; }
    public CannonState DamagedState { get; set; }
    public CannonState DestroyedState { get; set; }

    private CannonState _currentState;
    public CannonState CurrentState { 
        get => _currentState;
        set
        {
            if(_currentState != null) _currentState.Exit();
            _currentState = value;
            _currentState.Enter();
            _stateText.text = CurrentState.GetType().Name;
        }
    }

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

    public bool IsAimingAtTarget { get; set; }

    private int _maxHealth = 3;
    private int _maxBullets = 5;
    private float _bulletSpeed = 50f;
    private float _timeBetweenShooting = 1f;
    private float _timeBetweenReloadingBullets = .5f;

    private Coroutine _attackCoroutine;
    private Coroutine _reloadCoroutine;

    private void Awake()
    {
        Health = _maxHealth;
        BulletCount = _maxBullets;
        InitializeCannonStates();
    }

    private void InitializeCannonStates()
    {
        IdleState = new IdleCannonState(this);
        AttackingState = new AttackingCannonState(this);
        ReloadingState = new ReloadingCannonState(this);
        DamagedState = new DamagedCannonState(this);
        DestroyedState = new DestroyedCannonState(this);
        CurrentState = IdleState;
    }

    private void Update()
    {
        if (Target == null || !IsAimingAtTarget) return;

        _turret.LookAt(Target.position);
    }

    public void Attack()
    {
        CurrentState.Attack();
    }

    public void Stop()
    {
        CurrentState.Stop();
    }

    public void Damage()
    {
        CurrentState.Damage();
    }

    public void Repair()
    {
        CurrentState.Repair();
    }

    public void Destroy()
    {
        CurrentState.Destroy();
    }

    public void Revive()
    {
        CurrentState.Revive();
    }

    public void ShowTurret(bool show)
    {
        _turret.gameObject.SetActive(show);
    }

    public void RestoreHealth()
    {
        Health = _maxHealth;
    }

    public void StartShooting()
    {
        StopShooting();
        _attackCoroutine = StartCoroutine(ShootBullets());
    }

    public void StopShooting()
    {
        if (_attackCoroutine != null) StopCoroutine(_attackCoroutine);
    }

    public void StartReloading()
    {
        StopReloading();
        _reloadCoroutine = StartCoroutine(ReloadBullets());
        _stateText.text = CurrentState.GetType().Name;
    }

    public void StopReloading()
    {
        if (_reloadCoroutine != null) StopCoroutine(_reloadCoroutine);
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            yield return null;
            if (BulletCount == 0)
            {
                CurrentState = ReloadingState;
                yield break;
            }
            ShootBullet();
            yield return new WaitForSeconds(_timeBetweenShooting);
        }
    }

    private void ShootBullet()
    {
        BulletCount--;
        var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation).GetComponent<Rigidbody>();
        bullet.velocity = _shootPoint.forward * _bulletSpeed;
        _fireVfx.Play();
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
