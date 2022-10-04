using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BakingController : MonoBehaviour
{
    [SerializeField] private BakingModelHolder _modelHolder;

    private void Start()
    {
        _modelHolder.NotifyModelChanged();
    }

    public void Bake()
    {
        var model = _modelHolder.Model;
        var hasIngredients = model.Powder > 0 && model.Milk > 0 && model.Eggs > 0;
        var isGoodCook = Random.Range(0, 2) == 0;
        if (hasIngredients && isGoodCook)
        {
            model.Message = "Perfectly cooked!";
        }
        else if (isGoodCook)
        {
            model.Message = "No ingredients.";
        }
        else if (hasIngredients)
        {
            model.Message = "You are a terrible cook...";
        }
        else
        {
            model.Message = "Get out!";
        }
        model.Powder = 0;
        model.Milk = 0;
        model.Eggs = 0;
        _modelHolder.NotifyModelChanged();
    }

    public void IncreasePowder()
    {
        _modelHolder.Model.Powder += .1f;
        _modelHolder.NotifyModelChanged();
    }

    public void DecreasePowder()
    {
        _modelHolder.Model.Powder -= .1f;
        _modelHolder.NotifyModelChanged();
    }

    public void IncreaseEggs()
    {
        _modelHolder.Model.Eggs += 1;
        _modelHolder.NotifyModelChanged();
    }

    public void DecreaseEggs()
    {
        _modelHolder.Model.Eggs -= 1;
        _modelHolder.NotifyModelChanged();
    }

    public void IncreaseMilk()
    {
        _modelHolder.Model.Milk += .1f;
        _modelHolder.NotifyModelChanged();
    }

    public void DecreaseMilk()
    {
        _modelHolder.Model.Milk -= .1f;
        _modelHolder.NotifyModelChanged();
    }
}
