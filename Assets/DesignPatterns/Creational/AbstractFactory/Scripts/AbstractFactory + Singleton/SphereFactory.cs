using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryPlusSingleton
{
    public class SphereFactory : ShapeFactory
    {
        public override GameObject CreateBigShape()
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = Vector3.one * .5f;
            return sphere;
        }

        public override GameObject CreateMediumShape()
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            return sphere;
        }

        public override GameObject CreateSmallShape()
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = Vector3.one * 2f;
            return sphere;
        }
    }
}
