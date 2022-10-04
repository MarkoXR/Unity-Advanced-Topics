using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BakingIngredientsView : BakingView
{
    [SerializeField] private TMP_Text _powder;
    [SerializeField] private TMP_Text _milk;
    [SerializeField] private TMP_Text _eggs;
    [SerializeField] private TMP_Text _message;
    [Space]
    [SerializeField] private Button _bakeButton;
    [Space]
    [SerializeField] private Button _increasePowderButton;
    [SerializeField] private Button _decreasePowderButton;
    [Space]
    [SerializeField] private Button _increaseMilkButton;
    [SerializeField] private Button _decreaseMilkButton;
    [Space]
    [SerializeField] private Button _increaseEggsButton;
    [SerializeField] private Button _decreaseEggsButton;

    private void Start()
    {
        _bakeButton.onClick.AddListener(() => _viewManager.OnBakeClicked());

        _increasePowderButton.onClick.AddListener(() => _viewManager.OnPowderIncresed());
        _decreasePowderButton.onClick.AddListener(() => _viewManager.OnPowderDecreased());

        _increaseMilkButton.onClick.AddListener(() => _viewManager.OnMilkIncresed());
        _decreaseMilkButton.onClick.AddListener(() => _viewManager.OnMilkDecreased());

        _increaseEggsButton.onClick.AddListener(() => _viewManager.OnEggsIncresed());
        _decreaseEggsButton.onClick.AddListener(() => _viewManager.OnEggsDecreased());
    }

    public override void UpdateView(BakingModel model)
    {
        _powder.text = $"Powder: {model.Powder}";
        _milk.text = $"Milk: {model.Milk}";
        _eggs.text = $"Eggs: {model.Eggs}";
        _message.text = $"Message: {model.Message}";
    }
}
