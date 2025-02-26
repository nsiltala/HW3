using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public InputActionReference buttonInput;
    public Animator animator;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        buttonInput.action.Enable();
    }

    private bool isGrabbed = false;

    private void Update()
    {
        if (animator != null)
        {
            if (buttonInput == null) {
                return;
            }
            if (buttonInput.action.ReadValue<float>() > 0.5f && !isGrabbed)
            {
                isGrabbed = true;
                animator.SetTrigger("openTrig");
            }
            else if(buttonInput.action.ReadValue<float>() < 0.5f && isGrabbed)
            {
                isGrabbed = false;
                animator.SetTrigger("closeTrig");
            }
        }
    }

    private void OnDestroy()
    {
        buttonInput.action.Disable();
    }
}