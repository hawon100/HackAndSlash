using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� ������ ����

    public Vector3 offset = new Vector3(0f, 5f, -10f); // ī�޶�� �÷��̾� ���� ������

    private void LateUpdate()
    {
        // �÷��̾� ��ġ�� ���� ī�޶� ��ġ ����
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player.position); // �÷��̾ �ٶ󺸵��� ��
        }
    }
}
