using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public InputActionReference buttonInput;
    public Animator animator;
    private static readonly int IsPressed = Animator.StringToHash("isPressed");

    private void OnEnable()
    {
        buttonInput.action.Enable();
        buttonInput.action.performed += OnButtonPressed;
        buttonInput.action.canceled += OnButtonReleased;
    }

    private void OnDisable()
    {
        buttonInput.action.Disable();
        buttonInput.action.performed -= OnButtonPressed;
        buttonInput.action.canceled -= OnButtonReleased;
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        animator.SetBool(IsPressed, true);
    }

    private void OnButtonReleased(InputAction.CallbackContext context)
    {
        animator.SetBool(IsPressed, false);
    }
}
