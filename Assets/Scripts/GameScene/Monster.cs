using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Transform spawn;
    public float speed = 1.5f; // 몬스터 이동 속도
    public float followDistance = 20f; // 플레이어를 따라가기 시작하는 거리
    public float rayDistance = 1f; // 레이캐스트 거리
    public LayerMask obstacleLayer; // 장애물 레이어

    private Animator animator; // 애니메이터 컴포넌트
    private Vector2 lastMoveDirection; // 마지막 이동 방향을 저장
    private bool isReset = false;
    private bool goPlayer = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어와의 거리 계산
        float distance = Vector2.Distance(transform.position, player.position);

        //if (goPlayer || distance < followDistance)
        if (goPlayer)
        {
            // 플레이어를 따라가는 로직
            Transform target = isReset ? spawn : player;
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            lastMoveDirection = direction;

            // 장애물 체크
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, obstacleLayer);
            //if (hit.collider != null)
            //{
            //    // 장애물이 있는 경우 방향을 바꿔서 피하기
            //    direction = AvoidObstacle(direction, hit.normal);
            //}

            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, speed * Time.deltaTime);

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

    // 장애물을 피하는 방향을 계산하는 메서드
    Vector2 AvoidObstacle(Vector2 direction, Vector2 hitNormal)
    {
        Vector2 newDirection = Vector2.Reflect(direction, hitNormal);
        return newDirection.normalized;
    }


    public void GoRespawn()
    {
        isReset = true;
        
    }
    public void GoToPlayer()
    {
        isReset = false;
        goPlayer = true;
    }
}
