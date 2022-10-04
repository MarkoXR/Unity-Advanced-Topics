using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] private Tree _tree;

    [ContextMenu(nameof(MakeFruit))]
    public void MakeFruit()
    {
        _tree.CreateFruit();
    }
}
