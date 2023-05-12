using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Mover Mover;
    public Vector2 movementInput;
    [SerializeField]
    private InputActionReference movement, run;
    private Animator animatorR;

    private void Awake()
    {
        animatorR = GetComponent<Animator>();
        Mover = GetComponent<Mover>();
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();
        if (run.action.ReadValue<float>() == 1)
        {
            movementInput.x = -2f;
        }
        Mover.MovementInput = movementInput;
        animatorR.SetFloat("InputX", movementInput.x);
    }
}
