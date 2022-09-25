using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //[SerializeField] private IPlayer _player;
    [SerializeField] private PlayerOld _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _player.MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _player.MoveBack();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _player.MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _player.MoveLeft();
        }
    }
}
