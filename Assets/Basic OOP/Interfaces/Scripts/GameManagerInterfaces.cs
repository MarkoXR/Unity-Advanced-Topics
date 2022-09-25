using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interfaces
{
    public class GameManagerInterfaces : MonoBehaviour
    {
        public void OnClick()
        {
            var gameObjects = FindObjectsOfType<MonoBehaviour>();

            var jumpers = gameObjects.OfType<IJumps>();
            foreach (var jumper in jumpers)
            {
                jumper.Jump();
            }

            var pushables = gameObjects.OfType<IPushable>();
            foreach (var pushable in pushables)
            {
                pushable.Push();
            }
        }
    }
}