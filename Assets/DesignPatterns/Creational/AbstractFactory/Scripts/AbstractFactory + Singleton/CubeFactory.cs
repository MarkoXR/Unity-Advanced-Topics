using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AbstractFactoryPlusSingleton
{
    public class CubeFactory : ShapeFactory
    {
        public override GameObject CreateBigShape()
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = Vector3.one * .5f;
            return cube;
        }

        public override GameObject CreateMediumShape()
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            return cube;
        }

        public override GameObject CreateSmallShape()
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = Vector3.one * 2f;
            return cube;
        }
    }
}
