using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Driver : MonoBehaviour
{
    [SerializeField] [Tooltip("The gameobject will rotate x degrees per second")] private float steerSpeed = 360;
    [SerializeField] [Tooltip("The gameobject will move forward x units per second")]
    private float moveSpeed = 1;
    private float slowSpeed = 1f, boostSpeed = 4, originalSpeed = 0;

    private void Awake()
    {
        originalSpeed = moveSpeed;
        slowSpeed = moveSpeed / 2f + 2;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmountX = Input.GetAxis("Horizontal");
        float accelerateAmountY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, accelerateAmountY * Time.deltaTime * moveSpeed));
        transform.Rotate(new Vector3(0, 0, -steerAmountX * Time.deltaTime * steerSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Booster"))
        {
            moveSpeed += boostSpeed;
            slowSpeed = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        moveSpeed = originalSpeed;
    }
}
