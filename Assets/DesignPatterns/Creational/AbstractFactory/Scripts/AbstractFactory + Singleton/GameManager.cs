using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryPlusSingleton
{
    public class GameManager : MonoBehaviour
    {
        private List<GameObject> shapes = new List<GameObject>();

        private bool _isGameStarted;

        public void StartGame()
        {
            if (_isGameStarted == true) return;
            try
            {
                shapes.Add(ShapeFactory.Instance.CreateSmallShape());
                shapes.Add(ShapeFactory.Instance.CreateMediumShape());
                shapes.Add(ShapeFactory.Instance.CreateBigShape());
                _isGameStarted = true;
            }
            catch (NullReferenceException e)
            {
                Debug.LogError($"Shape factory has to be initialized first...\n" +
                    $"This can be prevented by disabling button if Abstract Factory hasn't been instantiated");
            }
            catch (Exception e)
            {
                Debug.LogError($"Unexpected error: {e}");
            }
        }

        public void EndGame()
        {
            if (_isGameStarted == false) return;
            foreach (var shape in shapes)
            {
                Destroy(shape);
            }
            shapes.Clear();
            _isGameStarted = false;
        }
    }
}
