using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    private Vector3 offset;


    void Start()
    {
        // 초기 거리 차이 계산 (카메라 위치 - 플레이어 위치)
        offset = transform.position - player.transform.position;
    }

    // Update 함수가 어떤 순서로 실행될지 알 수 없음 (eg. 카메라 src -> 플레이어 src 순서이면 X)
    // Update처럼 매 프레임 실행되지만, 다른 모든 Update 작업이 완료된 후에 실행
    void LateUpdate()
    {
        if (player != null)
        {
            // 카메라 위치 (플레이어 위치 + 오프셋)
            transform.position = player.transform.position + offset;
        }
    }
}
