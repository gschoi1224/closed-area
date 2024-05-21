using System.Collections;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private Animator animator;
    private bool isRunning = false;
    public float speed = 5f;
    public float idleTime = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartRunningAfterDelay(idleTime)); // 지연 후 실행
    }

    IEnumerator StartRunningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("startRunning");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Run"));
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
