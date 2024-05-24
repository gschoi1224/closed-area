using System.Collections;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private Animator animator;
    private bool isRunning = false;
    public float speed = 5f;
    public float idleTime = 1f;
    private bool isDisappear = false;
    public float fadeDuration = 2f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartRunningAfterDelay(idleTime)); // 지연 후 실행
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator StartRunningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("startRunning");
        SoundManager.instance.CatOn(0);
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Run"));
        SoundManager.instance.CatOn(3);
        isRunning = true;
    }

    IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color color = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - elapsed / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        gameObject.SetActive(false);
    }


    void Update()
    {
        if (isRunning)
        {
            if (transform.position.x > 6 && !isDisappear)
            {
                Debug.Log("disappear!!!!!");
                StartCoroutine(FadeOut());
                isDisappear = true;
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
