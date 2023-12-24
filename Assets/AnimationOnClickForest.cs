using UnityEngine;

public class AnimationOnClickForest : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to the GameObject.
        animator = GetComponent<Animator>();

        // Disable the Animator at the start so the animation doesn't play immediately.
        animator.enabled = false;
    }

    private void OnMouseDown()
    {
        // Check if the mouse clicked on the object's collider.
        // Note: OnMouseDown() works for 2D colliders like BoxCollider2D.
        // Make sure that the "isTrigger" property of the BoxCollider2D is set to true if needed.
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        // Enable the Animator to play the animation.
        animator.enabled = true;
        // Play the animation.
        animator.Play("ForestSelectBackPage"); // Replace "YourAnimationName" with the actual animation name.
    }
}
