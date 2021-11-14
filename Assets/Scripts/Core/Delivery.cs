using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames.DeliveryDriver.Core
{
    internal class Delivery : MonoBehaviour
    {
        [SerializeField] private Color32 colorShift = new Color32(1, 1, 1, 1);

        SpriteRenderer sr = null;
        Color originalColor;
        bool hasPackage = false;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            originalColor = sr.color;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Package") && !hasPackage)
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                sr.color = colorShift;
                collider.transform.position = new Vector2(Random.Range(-29.5f, 29.8f), Random.Range(-12.4f, 26.5f));
            }
            else if (collider.gameObject.CompareTag("Customer") && hasPackage)
            {
                Debug.Log("Package Delivered!");
                sr.color = originalColor;
                hasPackage = false;
            }
        }
    }
}
