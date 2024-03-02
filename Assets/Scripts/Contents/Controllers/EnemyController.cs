using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public string targetTag = "Player";  // Ÿ������ ���� ������Ʈ�� �±�
    public float detectionRadius = 10f;  // ���� ����
    public float returnRadius = 15f;     // ���ڸ��� ���ư��� ����
    private Transform target;            // ���� ���� ���� Ÿ��
    private Vector3 originalPosition;    // �ʱ� ��ġ

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        // ���� ���� ���� Ÿ���� �ִ��� Ȯ��
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                target = collider.transform;
                // Ÿ���� �����Ǹ� ���󰡱�
                agent.SetDestination(target.position);
                return;
            }
        }

        // ���� ���� ���� Ÿ���� ������ �ʱ� ��ġ�� ���ư���
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
