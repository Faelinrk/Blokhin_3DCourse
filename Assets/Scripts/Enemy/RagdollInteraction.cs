using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollInteraction : MonoBehaviour
{
    private Collider mainCollider;
    private Collider[] ragdollColliders;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainCollider = GetComponent<Collider>();
        ragdollColliders = GetComponentsInChildren<Collider>();
    }

    public void FallToRagdoll()
    {
        StartCoroutine(DisableColliders());
    }

    private IEnumerator DisableColliders()
    {
        
        mainCollider.enabled = false;
        foreach (var collider in ragdollColliders)
        {
            collider.enabled = true;
        }

        yield return new WaitForSecondsRealtime(.1f);
        animator.enabled = false;
    }
}
