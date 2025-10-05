# Roll-a-Ball

Unity Tutorial

<br>

**Course**  
[3D Beginner Game: Roll-a-Ball](https://learn.unity.com/course/roll-a-ball?version=2022.3)

<br>

**FIX**

- 플레이어 파괴 후 `MissingReferenceException` 발생
  - CameraController에 Null 체크 추가
- 큐브를 다 모아도 추적이 계속됨
  - 승리(count >= 12) 후 적 오브젝트를 파괴함으로써, "You Win" 이후 "You Lose" 상태로 전환되는 문제 수정
- 시작 시 충돌 지연
  - EnemyBody에 Rigidbody 컴포넌트를 추가하고 Is Kinematic을 활성화하여 정지 상태에서의 충돌 감지 문제 수정

<br>

👉 [Play Link](https://play.unity.com/en/games/752f1375-a6c9-4e85-bfe3-e6cf14f58328/rollaball-wozl)

<img width="504" height="374" alt="Image" src="https://github.com/user-attachments/assets/879af893-c9b2-4034-8e7f-4739ba9f11d0" />
