using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames.DeliveryDriver.Core
{
    internal class Collision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collided!!!");
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("It went through...");
        }
    }
}
