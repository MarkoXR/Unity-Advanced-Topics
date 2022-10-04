
public class DamagedCannonState : CannonState
{
    public DamagedCannonState(CleanCannon cannon) : base(cannon)
    {
    }

    public override void Damage()
    {
        base.Damage();
        if (_cannon.Health == 0) _cannon.CurrentState = _cannon.DestroyedState;
    }

    public override void Destroy()
    {
        base.Destroy();
        _cannon.CurrentState = _cannon.DestroyedState;
    }

    public override void Repair()
    {
        _cannon.RestoreHealth();
        _cannon.CurrentState = _cannon.IdleState;
    }
}
