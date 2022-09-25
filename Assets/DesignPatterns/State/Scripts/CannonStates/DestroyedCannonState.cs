
public class DestroyedCannonState : CannonState
{
    public DestroyedCannonState(CleanCannon cannon) : base(cannon)
    {
    }

    public override void Enter()
    {
        _cannon.ShowTurret(false);
    }

    public override void Exit()
    {
        _cannon.ShowTurret(true);
    }

    public override void Revive()
    {
        _cannon.RestoreHealth();
        _cannon.CurrentState = _cannon.IdleState;
    }
}
