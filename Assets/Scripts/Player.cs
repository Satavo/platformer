using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Mover Mover;
    public Vector2 movementInput, pointerInput;
    public Vector2 PointerInput => pointerInput;

    [SerializeField]
    private InputActionReference movement, pointerPosition;
    private Animator animatorR, animatorL;

    private void Awake()
    {
        animatorL = GetComponent<Animator>(); 
        animatorR = GetComponent<Animator>();
        Mover = GetComponent<Mover>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();
        Mover.MovementInput = movementInput;
        animatorR.SetFloat("InputX", movementInput.x);
        animatorL.SetFloat("InputX", movementInput.x);
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
