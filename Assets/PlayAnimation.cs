using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animation animation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(AnimationState animationState in animation) {
            animationState.enabled = true;
        }
    }
}
