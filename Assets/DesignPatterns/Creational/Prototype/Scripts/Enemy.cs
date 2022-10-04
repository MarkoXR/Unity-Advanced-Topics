using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public override NPC Clone()
    {
        return Instantiate(gameObject).GetComponent<Enemy>();       
    }
}
