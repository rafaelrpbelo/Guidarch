using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Camera cam;
    public Interactable focus;

    PlayerAttack attackCtrl;
    PlayerMovement movementCtrl;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        attackCtrl = this.GetComponent<PlayerAttack>();
        movementCtrl = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else {
                    RemoveFocus();
                    movementCtrl.MoveTo(hit.point);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus) {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            
            focus = newFocus;
            movementCtrl.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        movementCtrl.StopFollowingTarget();
    }
}
