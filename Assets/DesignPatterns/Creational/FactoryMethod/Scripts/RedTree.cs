using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTree : Tree
{
    [SerializeField] private GameObject _redFruit;

    public override GameObject CreateFruit()
    {
        return Instantiate(_redFruit);
    }
}
