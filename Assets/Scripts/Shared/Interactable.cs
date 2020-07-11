using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform interactableTransform = null;
    public float interactableRadius = 3f;
    public float stoppingDistance = .7f;

    private Transform player;
    private bool isFocus = false;
    private bool hasInteracted = false;
    
    public virtual void Interact() {
        Debug.Log("Interacting with " + transform.name);
    }

    void Awake() {
        SetDefaultInteractableTransform();
    }
    
    void Update() {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= interactableRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        SetDefaultInteractableTransform();
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(interactableTransform.position, interactableRadius);
    }

    void SetDefaultInteractableTransform()
    {
        if (interactableTransform == null)
            interactableTransform = transform;
    }
}
