using System.Collections;
using UnityEngine;

public class LockerManager : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerInside = false;
    private GameObject player;
    public Transform outsidePosition; // 플레이어가 나올 위치
    public Transform hidePosition;
    public Monster Monster;
    private SpriteRenderer spriteRenderer;
    private Color color;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            spriteRenderer = player.GetComponent<SpriteRenderer>();
            color = spriteRenderer.color;
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //}

    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.A) && !isPlayerInside)
        {
            StartCoroutine(EnterCabinet());   
        }
        if (isPlayerInside && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            StartCoroutine(ExitCabinet());
        }
    }

    IEnumerator EnterCabinet()
    {
        animator.SetTrigger("open");
        if (Monster != null)
        {
            Monster.GoRespawn();
        }
        SoundManager.instance.PlayEffect(6);
        yield return new WaitForSeconds(0.35f); // 애니메이션 길이에 맞게 조정
        //player.transform.position = hidePosition.position;
        //player.SetActive(false); // 플레이어를 보이지 않게 
        spriteRenderer.color = new Color(0,0,0,0);
        isPlayerInside = true;
    }

    IEnumerator ExitCabinet()
    {
        animator.SetTrigger("open");
        if (Monster != null)
        {
            Monster.GoToPlayer();
        }
        SoundManager.instance.PlayEffect(6);
        yield return new WaitForSeconds(0.35f); // 애니메이션 길이에 맞게 조정
        //player.transform.position = outsidePosition.position; // 플레이어를 캐비닛 밖으로 이동
        //player.SetActive(true); // 플레이어를 보이게 함
        isPlayerInside = false;
        spriteRenderer.color = color;
    }
}
