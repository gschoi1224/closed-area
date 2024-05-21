using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    private Button currentButton;
    private Vector3 originalScale;
    private bool isHighlighted = false;

    void Start()
    {
        // 초기 설정
        currentButton = startButton;
        originalScale = startButton.transform.localScale;
        HighlightButton(currentButton);

        // 버튼 클릭 이벤트 연결
        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);

    }

    void Update()
    {
        // 방향키 입력 처리
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentButton != startButton)
        {
            HighlightButton(startButton);
            currentButton = startButton;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentButton != exitButton)
        {
            HighlightButton(exitButton);
            currentButton = exitButton;
        }

        // 엔터키 입력 처리
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            currentButton.onClick.Invoke();
        }
        // 하이라이트 애니메이션
        if (isHighlighted)
        {
            float scale = 1 + Mathf.PingPong(Time.time * 0.5f, 0.2f); // 커졌다 작아지는 효과
            currentButton.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    void HighlightButton(Button button)
    {
        // 버튼 포커스 효과
        EventSystem.current.SetSelectedGameObject(button.gameObject);
        isHighlighted = true;

        if (currentButton != null && currentButton != button)
        {
            currentButton.transform.localScale = originalScale; // 원래 크기
        }
    }

    void OnStartButtonClick()
    {
        // 게임 시작 로직
        SceneManager.LoadScene("GameScene");
    }

    void OnExitButtonClick()
    {
        // 게임 종료 로직
        Application.Quit();
        Debug.Log("Exit button clicked"); // 에디터에서 작동 확인용
    }
}