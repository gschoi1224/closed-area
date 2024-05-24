using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float followDistance = 3.0f; // 플레이어를 따라가는 거리
    public float speed = 2.0f; // 고양이의 이동 속도
    private bool isFollowing = false;
    private Animator animator; // 애니메이터 컴포넌트

    void Start()
    {
        //animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
    }

    void Update()
    {
        if (isFollowing)
        {
            FollowPlayer();
        }
        else
        {
            //animator.SetTrigger("Idle");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
            //animator.SetTrigger("StartRunning"); // 걷는 애니메이션 트리거
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = false;
            //animator.SetTrigger("Idle"); // 멈춤 애니메이션 트리거
        }
    }

    void FollowPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > followDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            isFollowing = false;
            //animator.SetTrigger("Idle"); // 플레이어와 가까워지면 멈춤 애니메이션 트리거
        }
    }
}
