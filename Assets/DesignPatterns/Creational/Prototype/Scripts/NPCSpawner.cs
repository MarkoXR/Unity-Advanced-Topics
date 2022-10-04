using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private NPC _targetNPC;

    [ContextMenu(nameof(CreateClone))]
    public void CreateClone()
    {
        _targetNPC.Clone();
    }
}
