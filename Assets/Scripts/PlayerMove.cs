using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed; // 플레이어의 이동 속도
    public Vector2 vector; // 플레이어의 방향 벡터
    public Animator animator; // 애니메이터 컴포넌트
    public bool IsKeydown = false; // A키 입력 여부
    public bool useflash = false; // 플래시라이트 사용 여부
    public bool haveitem = false;
    public bool useitem = false;
    public bool uselighter = false;
    public string itemname;
    private bool isActive = false;
    public float idleTime = 1f;
    public bool hasSilverKey = false;
    public bool hasRedKey = false;
    public bool saveCat = false;

    // Start is called before the first frame update
    void Start()
    {
        // 코루틴 시작
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(idleTime);
        isActive = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsKeydown = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            IsKeydown = false;
        }
        if (Input.GetKeyDown (KeyCode.S) && haveitem)
        {
            useitem = true;
        }
        if (Input.GetKeyUp (KeyCode.S))
        {
            useitem = false;
        }
    }

    private void FixedUpdate()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (!isActive)
        {
            return;
        }

        // 방향키 입력 처리
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }

        // 수평과 수직 방향을 동시에 입력받을 경우, 우선순위를 적용하여 이동 방향 설정
        if (moveX != 0)
        {
            moveY = 0; // 수평 이동 시 수직 이동을 무시
        }

        vector.Set(moveX, moveY);

        bool isWalking = vector != Vector2.zero;

        if (isWalking)
        {
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
        }
        animator.SetBool("Walking", isWalking);

        GetComponent<Rigidbody2D>().velocity = vector * speed;
    }
}