using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayer : MonoBehaviour
{
    public abstract void MoveForward();
    public abstract void MoveBack();
    public abstract void MoveLeft();
    public abstract void MoveRight();
}
