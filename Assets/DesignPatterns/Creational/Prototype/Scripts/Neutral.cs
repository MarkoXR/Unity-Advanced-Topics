using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutral : NPC
{
    public override NPC Clone()
    {
        return Instantiate(gameObject).GetComponent<Neutral>();
    }
}
