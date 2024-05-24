using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    public Text[] texts; // 비밀번호를 표시할 Text
    public static string correctPassword = "1102"; // 올바른 비밀번호
    private string enteredPassword = ""; // 입력된 비밀번호
    public SecondDoor Door;
    public KeypadManager keyManager;

    void Start()
    {
        // 초기화
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "";
        }
        enteredPassword = "";
    }

    // 버튼 클릭 시 호출되는 메소드
    public void OnButtonClick(string character)
    {
        Debug.Log(character);
        // 입력된 문자를 추가
        texts[enteredPassword.Length].text = character;
        enteredPassword += character;
        if (enteredPassword.Length == 4)
        {
            CheckPassword();
        }
    }

    // 엔터 버튼 클릭 시 호출되는 메소드
    public void CheckPassword()
    {
        // 비밀번호 일치 확인
        if (enteredPassword == correctPassword)
        {
            Debug.Log("Correct Password");
            Door.OpenDoor();
            keyManager.ExitCanvas(true);
            // 비밀번호가 일치할 경우 실행할 로직 추가
        }
        else
        {
            Debug.Log("Incorrect Password");
            // 비밀번호가 일치하지 않을 경우 실행할 로직 추가
        }

        // 입력 초기화
        enteredPassword = "";
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "";
        }
    }

    // 클리어 버튼 클릭 시 호출되는 메소드
    public void OnClearButtonClick()
    {
        // 입력 초기화
        enteredPassword = "";
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "";
        }
    }
}
