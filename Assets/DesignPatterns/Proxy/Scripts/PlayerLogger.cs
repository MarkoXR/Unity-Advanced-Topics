using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogger : IPlayer
{
    [SerializeField] private Player _player;

    public override void MoveBack()
    {
        Debug.Log("Moving back");
        _player.MoveBack();
    }

    public override void MoveLeft()
    {
        Debug.Log("Move left");
        _player.MoveLeft();
    }

    public override void MoveRight()
    {
        Debug.Log("Move right");
        _player.MoveRight();
    }

    public override void MoveForward()
    {
        Debug.Log("Move forward");
        _player.MoveForward();
    }
}
