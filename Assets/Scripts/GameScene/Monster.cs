using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float speed = 2.0f; // 몬스터의 이동 속도
    public float followDistance = 20; // 몬스터가 플레이어를 따라가기 시작하는 거리

    private Animator animator; // 애니메이터 컴포넌트
    private Vector2 lastMoveDirection; // 마지막 이동 방향을 저장

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어와의 거리 계산
        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log(distance);
        Debug.Log(followDistance);
        Debug.Log(distance < followDistance);

        if (distance < followDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            lastMoveDirection = direction;

            // 애니메이션 설정 (방향에 따른 애니메이션 트리거)
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // 좌우 이동
                if (direction.x > 0)
                {
                    animator.SetTrigger("MoveRight");
                }
                else
                {
                    animator.SetTrigger("MoveLeft");
                }
            }
            else
            {
                // 상하 이동
                if (direction.y > 0)
                {
                    animator.SetTrigger("MoveTop");
                }
                else
                {
                    animator.SetTrigger("MoveBottom");
                }
            }
        }
        else
        {
            // 플레이어가 일정 거리 밖에 있는 경우 멈춤 (idle 애니메이션 트리거)
            animator.SetTrigger("Idle");
        }
    }
}
