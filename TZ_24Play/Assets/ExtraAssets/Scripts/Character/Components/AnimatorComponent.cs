using UnityEngine;

public class AnimatorComponent
{
    Animator animator;

    public AnimatorComponent(Transform meshTransform, ICollisionEvent collisionEvent)
    {
        animator = meshTransform.GetComponent<Animator>();

        collisionEvent.Add_OnPickUp_Listener(Play_JumpAnimation);
    }

    private void Play_JumpAnimation()
    {
        animator.SetTrigger("Jump");
    }
}
