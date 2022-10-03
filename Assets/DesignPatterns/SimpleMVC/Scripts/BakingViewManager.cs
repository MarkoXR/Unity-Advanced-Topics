using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingViewManager : BakingModelObserver
{
    [field: SerializeField] public BakingView IngredientsView { get; private set; }
    [field: SerializeField] public BakingModelSubject ModelSubject { get; private set; }
    [field: SerializeField] public BakingController Controller { get; set; }
    public BakingView CurrentView { get; set; }

    private void Start()
    {
        IngredientsView.Initialize(this);
        CurrentView = IngredientsView;
        ModelSubject.RegisterObserver(this);
    }

    public void OnBakeClicked()
    {
        Controller.Bake();
    }

    public void OnPowderIncresed()
    {
        Controller.IncreasePowder();
    }

    public void OnPowderDecreased()
    {
        Controller.DecreasePowder();
    }

    public override void UpdateView(BakingModel model)
    {
        CurrentView.UpdateView(model);
    }

    public void OnEggsDecreased()
    {
        Controller.DecreaseEggs();
    }

    public void OnEggsIncresed()
    {
        Controller.IncreaseEggs();
    }

    public void OnMilkDecreased()
    {
        Controller.DecreaseMilk();
    }

    public void OnMilkIncresed()
    {
        Controller.IncreaseMilk();
    }
}
