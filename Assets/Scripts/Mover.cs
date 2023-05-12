using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rigidb2d;
    public float animationSpeed;
    [SerializeField]
    private float maxSpeed = 2, acceleration = 50, deacceleration = 100;
    [SerializeField]
    private float currentSpeed = 0;
    private Vector2 prevMovementInput;
    public Vector2 MovementInput { get; set; }

    private void Awake()
    {
        rigidb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (MovementInput.magnitude > 0 && currentSpeed >= 0)
        {
            prevMovementInput = MovementInput;
            currentSpeed += acceleration * maxSpeed * Time.fixedDeltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.fixedDeltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rigidb2d.velocity = new Vector2(animationSpeed * maxSpeed * Time.fixedDeltaTime, 0);
    }
}
