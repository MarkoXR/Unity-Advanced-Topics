using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTree : Tree
{
    [SerializeField] private GameObject _greenFrruit;

    public override GameObject CreateFruit()
    {
        return Instantiate(_greenFrruit);
    }
}
