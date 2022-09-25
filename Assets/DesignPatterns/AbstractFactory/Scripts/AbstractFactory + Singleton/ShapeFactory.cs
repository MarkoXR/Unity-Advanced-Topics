using UnityEngine;

namespace AbstractFactoryPlusSingleton
{
    public abstract class ShapeFactory
    {
        public static ShapeFactory Instance { get; set; }
        public abstract GameObject CreateSmallShape();
        public abstract GameObject CreateMediumShape();
        public abstract GameObject CreateBigShape();
    }
}
