using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer
{
    public override void MoveBack()
    {
        transform.position = transform.position + Vector3.back;
    }

    public override void MoveLeft()
    {
        transform.position = transform.position + Vector3.left;
    }

    public override void MoveRight()
    {
        transform.position = transform.position + Vector3.right;
    }

    public override void MoveForward()
    {
        transform.position = transform.position + Vector3.forward;
    }
}
