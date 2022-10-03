using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BakingModelObserver : MonoBehaviour
{
    public abstract void UpdateView(BakingModel model);
}
