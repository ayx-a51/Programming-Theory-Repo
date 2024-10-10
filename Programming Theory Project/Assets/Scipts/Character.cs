using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line to import TextMeshPro

public class Character : MonoBehaviour
{
    [SerializeField] protected string TypeName;
    [SerializeField] protected TextMeshProUGUI dialogueText; // Add this line
    protected Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // This function can be overridden in child classes
    protected virtual void Talk()
    {
        Debug.Log(TypeName + " is talking.");
        StartCoroutine(ShowDialogueText(TypeName + " is talking."));
    }

    // Add this new coroutine
    protected IEnumerator ShowDialogueText(string message)
    {
        dialogueText.text = message;
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
    }

    public virtual void OnMouseDown()
    {
        Talk();
        StartCoroutine(PlayMeleeAnimation());
    }
    IEnumerator PlayMeleeAnimation()
    {
        animator.Play("Melee_OneHanded");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.Play("Idle");
    }
}
