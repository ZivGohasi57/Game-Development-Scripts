using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTenderBehaviour : MonoBehaviour
{
    public int State = 0; 
    public GameObject[] waypoints; 
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
    public AudioSource audioSource;

    public float finalWaitTime = 30f; 
    private int currentWaypointIndex = 0;

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned!");
            return;
        }

        MoveToNextWaypoint();
    }

    void Update()
    {
        
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            
            FaceTarget(waypoints[currentWaypointIndex].transform);

            if (currentWaypointIndex < waypoints.Length - 1)
            {
                
                if (State == 0)
                {
                    StartCoroutine(WaitAtWaypoint());
                }
            }
            else
            {
                
                if (State != 2)
                {
                    StartCoroutine(WaitAtFinalWaypoint());
                }
            }
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        State = 1; 
        animator.SetInteger("State", State); 

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        yield return new WaitUntil(() => !audioSource.isPlaying);

        yield return new WaitForSeconds(1f);

        State = 0; 
        animator.SetInteger("State", State);

        MoveToNextWaypoint();
    }

    private IEnumerator WaitAtFinalWaypoint()
    {
        State = 2; 
        animator.SetInteger("State", State); 

        yield return new WaitForSeconds(finalWaitTime);

        State = 0; 
        animator.SetInteger("State", State);

        
        currentWaypointIndex = 0;
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
            currentWaypointIndex++;
        }
    }

    private void FaceTarget(Transform target)
    {
        
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0; 

        if (direction != Vector3.zero)
        {
            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
