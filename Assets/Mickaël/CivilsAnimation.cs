using UnityEngine;

public class CivilsAnimation
{
    

    private static bool GetRandomBool()
    {
        float value = Random.value;
        if(value < 0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void AnimationManager(state actualState, Animator animator)
    {
        switch (actualState)
        {
            case state.Standing:
                animator.SetBool("RunOne", false);
                animator.SetBool("RunTwo", false);
                animator.SetBool("Walk", false);
                if (GetRandomBool())
                {
                    animator.SetBool("IdleOne", true);
                }
                else
                {
                    animator.SetBool("IdleTwo", true);
                }
                break;
            case state.Walking:
                animator.SetBool("IdleOne", false);
                animator.SetBool("IdleTwo", false);
                animator.SetBool("RunOne", false);
                animator.SetBool("RunTwo", false);
                animator.SetBool("Walk", true);
                break;
            case state.Burning:
                animator.SetBool("IdleOne", false);
                animator.SetBool("IdleTwo", false);
                animator.SetBool("Walk", false);
                if (GetRandomBool())
                {
                    animator.SetBool("RunOne", true);
                }
                else
                {
                    animator.SetBool("RunTwo", true);
                }
                break;
            case state.Dead:
                animator.SetBool("Dead", true);
                break;
        }
    }
}
