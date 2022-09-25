using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CannonState
{
    protected CleanCannon _cannon;

    public CannonState(CleanCannon cannon)
    {
        _cannon = cannon;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Attack()
    {
    }

    public virtual void Damage()
    {
        _cannon.Health = _cannon.Health == 0 ? _cannon.Health : _cannon.Health - 1;
    }

    public virtual void Destroy()
    {
        _cannon.Health = 0;
    }

    public virtual void Repair()
    {
    }

    public virtual void Revive()
    {
    }

    public virtual void Stop()
    {
    }
}
