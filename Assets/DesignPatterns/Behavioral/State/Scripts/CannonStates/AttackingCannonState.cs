
public class AttackingCannonState : CannonState
{
    public AttackingCannonState(CleanCannon cannon) : base(cannon)
    {
    }

    public override void Enter()
    {
        _cannon.IsAimingAtTarget = true;
        _cannon.StartShooting();
    }

    public override void Exit()
    {
        _cannon.IsAimingAtTarget = false;
        _cannon.StopShooting();
    }

    public override void Damage()
    {
        base.Damage();
        _cannon.CurrentState = _cannon.Health == 0 ? _cannon.DestroyedState : _cannon.DamagedState;
    }

    public override void Destroy()
    {
        base.Destroy();
        _cannon.CurrentState = _cannon.DestroyedState;
    }

    public override void Repair()
    {
        _cannon.RestoreHealth();
    }

    public override void Stop()
    {
        _cannon.CurrentState = _cannon.IdleState;
    }
}
