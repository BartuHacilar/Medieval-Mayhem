using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpSecretLevel : MonoBehaviour
{
    public int targetSceneBuildIndex = 9;
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to the GameObject.
        animator = GetComponent<Animator>();

        // Disable the Animator at the start so the animation doesn't play immediately.
        animator.enabled = false;

        // Subscribe to the animation event.
        AnimationEventReceiver animationEventReceiver = new AnimationEventReceiver(this);
        animationEventReceiver.OnAnimationEnd += OnAnimationEnd;
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
        animator.Play("SecretLevelPopUp"); // Replace "YourAnimationName" with the actual animation name.
    }

    private void OnAnimationEnd()
    {
        // This method will be called when the animation finishes.
        SceneManager.LoadScene(targetSceneBuildIndex);
    }

    // Helper class to receive animation events
    private class AnimationEventReceiver : MonoBehaviour
    {
        public delegate void AnimationEndDelegate();
        public event AnimationEndDelegate OnAnimationEnd;

        public AnimationEventReceiver(PopUpSecretLevel parent)
        {
            // Ensure that this script is attached to the same GameObject as the animator.
            parent.animator.gameObject.AddComponent<AnimationEventReceiver>();
        }

        private void AnimationEnd()
        {
            // Trigger the event when the animation ends.
            OnAnimationEnd?.Invoke();
        }
    }
}
