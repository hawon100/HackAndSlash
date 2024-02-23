using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 연결할 변수

    public Vector3 offset = new Vector3(0f, 5f, -10f); // 카메라와 플레이어 간의 오프셋

    private void LateUpdate()
    {
        // 플레이어 위치에 따라 카메라 위치 조정
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player.position); // 플레이어를 바라보도록 함
        }
    }
}
