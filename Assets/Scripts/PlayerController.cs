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

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        attackCtrl = this.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject != null && selectedObject.CompareTag("Enemy"))
                selectedObject.SendMessage("Interact", "deselect");

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);

                if (hit.collider != null && hit.collider.gameObject != null)
                {
                    selectedObject = hit.collider.gameObject;

                    if (selectedObject.CompareTag("Enemy"))
                        selectedObject.SendMessage("Interact", "select");
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
