using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryPlusSingleton
{
    public class GameTypeController : MonoBehaviour
    {
        public void OnSphereGameChosen()
        {
            ShapeFactory.Instance = new SphereFactory();
        }

        public void OnCubeGameChosen()
        {
            ShapeFactory.Instance = new CubeFactory();
        }
    }
}
