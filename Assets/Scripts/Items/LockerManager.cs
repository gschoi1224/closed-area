using System.Collections;
using UnityEngine;

public class LockerManager : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerInside = false;
    private GameObject player;
    public Transform outsidePosition; // 플레이어가 나올 위치
    public Transform hidePosition;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //player = null;
        }
    }

    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.A) && !isPlayerInside)
        {
            StartCoroutine(EnterCabinet());   
        }
        if (isPlayerInside && Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ExitCabinet());
        }
    }

    IEnumerator EnterCabinet()
    {
        animator.SetTrigger("open");
        Debug.Log(hidePosition.position);
        yield return new WaitForSeconds(0.35f); // 애니메이션 길이에 맞게 조정
        player.transform.position = hidePosition.position;
        player.SetActive(false); // 플레이어를 보이지 않게 함
        isPlayerInside = true;
    }

    IEnumerator ExitCabinet()
    {
        animator.SetTrigger("open");
        yield return new WaitForSeconds(0.35f); // 애니메이션 길이에 맞게 조정
        player.transform.position = outsidePosition.position; // 플레이어를 캐비닛 밖으로 이동
        player.SetActive(true); // 플레이어를 보이게 함
        isPlayerInside = false;
        player = null;
    }
}
