using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Human : Character
{
    // POLYMORPHISM
    protected override void Talk()
    {
        Debug.Log("I am a human, and I'm the best!");
        StartCoroutine(ShowDialogueText("I am a human, and I'm the best!"));
    }

    // POLYMORPHISM
    public override void OnMouseDown()
    {
        Talk();
        StartCoroutine(PlayHumanAnimation());
    }

    IEnumerator PlayHumanAnimation()
    {
        animator.Play("BowShoot");
        yield return null;
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);
        animator.Play("Idle");
    }
}
