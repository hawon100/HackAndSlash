using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public string targetTag = "Player";  // 타겟으로 삼을 오브젝트의 태그
    public float detectionRadius = 10f;  // 감지 범위
    public float returnRadius = 15f;     // 제자리로 돌아가는 범위
    private Transform target;            // 현재 추적 중인 타겟
    private Vector3 originalPosition;    // 초기 위치

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        // 감지 범위 내에 타겟이 있는지 확인
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                target = collider.transform;
                // 타겟이 감지되면 따라가기
                agent.SetDestination(target.position);
                return;
            }
        }

        // 감지 범위 내에 타겟이 없으면 초기 위치로 돌아가기
        if (Vector3.Distance(transform.position, originalPosition) > returnRadius)
        {
            target = null;
            agent.SetDestination(originalPosition);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
