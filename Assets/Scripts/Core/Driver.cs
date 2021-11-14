using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Driver : MonoBehaviour
{
    [SerializeField] [Tooltip("The gameobject will rotate x degrees per second")] private float steerSpeed = 360;
    [SerializeField] [Tooltip("The gameobject will move forward x units per second")]
    private float moveSpeed = 1;
    private float slowSpeed = 0.5f, boostSpeed = 4;

    private void Awake()
    {
        slowSpeed = moveSpeed / 2f + 2;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmountX = Input.GetAxis("Horizontal");
        float steerAmountY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, steerAmountY * Time.deltaTime * moveSpeed));
        transform.Rotate(new Vector3(0, 0, -steerAmountX * Time.deltaTime * steerSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Booster"))
        {
            moveSpeed += boostSpeed;
            slowSpeed = moveSpeed / 2f + 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}
