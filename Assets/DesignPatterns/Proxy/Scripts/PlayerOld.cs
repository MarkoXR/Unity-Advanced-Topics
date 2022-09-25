using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOld : MonoBehaviour
{
    public void MoveBack()
    {
        Debug.Log("Move forward");
        transform.position = transform.position + Vector3.back;
    }

    public void MoveLeft()
    {
        Debug.Log("Move right");
        transform.position = transform.position + Vector3.left;
    }

    public void MoveRight()
    {
        Debug.Log("Move left");
        transform.position = transform.position + Vector3.right;
    }

    public void MoveForward()
    {
        Debug.Log("Moving back");
        transform.position = transform.position + Vector3.forward;
    }
}
