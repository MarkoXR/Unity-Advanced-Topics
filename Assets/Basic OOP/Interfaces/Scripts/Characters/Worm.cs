using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    [RequireComponent(typeof(Rigidbody))]
    public class Worm : MonoBehaviour, IPushable
    {
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Push()
        {
            rigidbody.velocity += Vector3.forward * 2f;
        }
    }
}