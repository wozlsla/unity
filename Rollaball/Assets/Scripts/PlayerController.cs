using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // 플레이어 오브젝트의 물리적 움직임을 제어
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    /* --------------- Unity Life Cycle Functions (유니티 생명 주기 함수) --------------- */
    // 스크립트가 활성화된 후, Update가 처음 호출되기 직전에 단 한 번 호출 
    void Start()
    {
        // 스크립트가 부착된 게임 오브젝트에서 Rigidbody 컴포넌트를 가져와서 할당
        rb = GetComponent<Rigidbody>();
        count = 0;

        // 초기화된 점수 UI 출력
        SetCountText();

        winTextObject.SetActive(false);
    }

    // 고정된 시간 간격(프레임 속도와 무관)으로 호출
    // Rigidbody에 힘을 적용하거나 충돌을 처리하는 등 모든 물리 계산 코드는 여기에 작성해야 신뢰성이 보장됨
    void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }
    /* ------------------------------ */

    /* ------------- Input System Callback Function (입력 시스템 콜백 함수) ------------- */
    // Called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // InputValue(입력값)에서 실제 움직임 데이터(2차원 벡터: X, Y)를 추출하여 할당
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    /* ------------------------------ */

    // (OnTrigger) 수집 이벤트 감지 핸들러
    //      플레이어와 수집 오브젝트 사이에 실제 물리적 충돌을 만들지 않고 접촉만 감지
    //      수집 오브젝트는 Is Trigger 속성이 켜져 있어야 함
    // 플레이어 게임 오브젝트가 트리거 콜라이더에 처음 닿았을 때 호출됨 -> 접촉한 트리거 콜라이더에 대한 참조(reference)를 전달받음: `other`
    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag
        if (other.gameObject.CompareTag("PickUp"))
        {
            // other 콜라이더와 접촉한 게임 오브젝트 비활성화 (making it disappear)
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
}

/*

## Rigidbody의 3가지 유형

1. Standard Rigidbody: (Is Kinematic 비활성화, Use Gravity 활성화)
  - 제어: 물리 엔진의 힘(중력, AddForce 등)으로만 제어됩니다. (예: 플레이어 공)

2. Kinematic Rigidbody: (Is Kinematic 활성화)
  - 제어: 스크립트의 transform으로만 제어됩니다. 외부 힘에 반응하지 않습니다.
  - 용도: 움직이는 플랫폼, 회전하는 수집 오브젝트, 엘리베이터 등 일정한 움직임이 필요한 오브젝트.

3. Static Collider: (Rigidbody 없음)
  - 제어: 움직이지 않으며, 움직이면 성능 문제가 발생합니다.
  - 용도: 벽, 바닥, 건물 등 고정된 환경 오브젝트.

*/