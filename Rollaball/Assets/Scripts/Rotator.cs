using UnityEngine;

public class Rotator : MonoBehaviour
{

    // 비물리적 움직임 (회전, 일반적인 이동, 카메라 추적, 입력 감지)를 처리
    void Update()
    {
        // `마지막 프레임 업데이트 이후 경과된 시간(초 단위)`을 곱함
        // -> 프레임 길이에 따라 값이 동적으로 변경 (eg. 100fps vs 50fps)
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}


/*

## Transform과 Translate/Rotate의 관계
게임 오브젝트의 `Transform(변형)`은 유니티에서 가장 기본이 되는 컴포넌트이며, 모든 게임 오브젝트가 가짐.

Transform 컴포넌트에는 오브젝트의 3가지 핵심 정보가 있다:
- Position (위치): 월드 공간에서의 X, Y, Z 좌표
- Rotation (회전): 오브젝트의 방향 (오일러 각 또는 쿼터니언)
- Scale (크기): 오브젝트의 X, Y, Z 방향 크기

`transform.Translate(Vector3)`: Position 변환 -> 현재 위치에서 지정된 방향과 거리만큼 이동시킴
`transform.Rotate(Vector3)`: Rotation 변환 -> 현재 방향에서 지정된 축을 중심으로 회전시킴

## Vector3 변수 vs 세 개의 float 값
컴퓨터가 정보를 다루는 방식의 차이

- Vector3 (데이터 구조)
    - 세 개의 float 값 (X, Y, Z)을 하나로 묶어놓은 데이터 타입 (구조체)
    - Unity에서 3차원 데이터를 다루는 표준 (권장)
- 세 개의 float 값 (개별 데이터)
    - 각각 독립된 세 개의 숫자 변수

*/