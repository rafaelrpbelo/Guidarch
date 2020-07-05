using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Camera cam;
    public GameObject selectedObject;

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
                movementCtrl.MoveTo(hit.point);

                if (hit.collider != null && hit.collider.gameObject != null)
                {
                    selectedObject = hit.collider.gameObject;
                }
            }
        }

        if (selectedObject != null)
        {
            if (attackCtrl.CanAttack(selectedObject))
                attackCtrl.Attack(selectedObject);
        }
    }
}
