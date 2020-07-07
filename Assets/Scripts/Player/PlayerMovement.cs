using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    public Transform targetToFollow;
    public float speedToFaceTarget = 5f;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (targetToFollow != null)    
        {
            MoveTo(targetToFollow.position);
            FaceTarget();
        }
    }

    public void MoveTo (Vector3 point)
    {
        navMeshAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        Debug.Log("Following target: " + newTarget.name);
        navMeshAgent.stoppingDistance = newTarget.interactableRadius * newTarget.stoppingDistance;
        targetToFollow = newTarget.interactableTransform;    
    }

    public void StopFollowingTarget()
    {
        navMeshAgent.stoppingDistance = 0f;
        targetToFollow = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (targetToFollow.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speedToFaceTarget * Time.deltaTime);
    }
}
