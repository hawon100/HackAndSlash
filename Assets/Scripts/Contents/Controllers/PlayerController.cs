using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, 0f, v).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 moveDestination = transform.position + moveDirection;
            agent.SetDestination(moveDestination);
        }
    }

    void Attack()
    {
        bool click = Input.GetMouseButtonDown(0);

        if (click)
        {

        }
    }
}
