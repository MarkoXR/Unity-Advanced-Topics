using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    [RequireComponent(typeof(Rigidbody))]
    public class ChuckNorris : MonoBehaviour, IJumps
    {
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            rigidbody.velocity += Vector3.up * 3f;
        }
    }
}