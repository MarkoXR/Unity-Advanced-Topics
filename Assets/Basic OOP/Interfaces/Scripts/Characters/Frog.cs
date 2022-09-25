using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    [RequireComponent(typeof(Rigidbody))]
    public class Frog : MonoBehaviour, IJumps, IPushable
    {
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            rigidbody.velocity += Vector3.up * 2f;
        }

        public void Push()
        {
            rigidbody.velocity += Vector3.forward * 2f;
        }
    }
}