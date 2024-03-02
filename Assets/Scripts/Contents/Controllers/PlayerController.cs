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
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� ���� ����
        Vector3 moveDirection = new Vector3(h, 0f, v).normalized;

        // NavMeshAgent�� �̵� ��ǥ ����
        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 moveDestination = transform.position + moveDirection;
            agent.SetDestination(moveDestination);
        }
    }
}
