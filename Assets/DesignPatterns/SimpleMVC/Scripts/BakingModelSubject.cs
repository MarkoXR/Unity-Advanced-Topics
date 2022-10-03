using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BakingModelSubject : MonoBehaviour
{
    public BakingModel Model { get; set; } = new BakingModel();

    private HashSet<BakingModelObserver> _observers = new HashSet<BakingModelObserver>();

    public void RegisterObserver(BakingModelObserver observer)
    {
        _observers.Add(observer);
    }

    public void UnregisterObserver(BakingModelObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyModelChanged()
    {
        foreach (var observer in _observers)
        {
            observer.UpdateView(Model);
        }
    }
}
