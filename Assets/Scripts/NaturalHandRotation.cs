using UnityEngine;

public class NaturalHandRotation : MonoBehaviour
{
    // The target object (e.g., VR controller) that the hand should follow
    public Transform target;

    // Offset to adjust the hand's rotation relative to the target
    public Quaternion rotationOffset = Quaternion.identity;

    void Update()
    {
        if (target != null)
        {
            // Match the hand's rotation to the target's rotation
            transform.rotation = target.rotation * rotationOffset;
        }
    }
}
