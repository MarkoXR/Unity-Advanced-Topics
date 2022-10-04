using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BakingView : MonoBehaviour
{
    protected BakingViewManager _viewManager;

    public void Initialize(BakingViewManager bakingViewManager)
    {
        _viewManager = bakingViewManager;
    }

    public abstract void UpdateView(BakingModel model);
}
