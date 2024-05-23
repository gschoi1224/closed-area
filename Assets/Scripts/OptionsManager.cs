using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance { get; private set; }

    public GameObject OptionsPanel;
    public Slider sfxVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider gammaSlider;
    public Button saveButton;
    public Button cancelButton;

    private float sfxVolume = 1.0f;
    private float bgmVolume = 1.0f;
    private float gammaValue = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadOptions();

        sfxVolumeSlider.value = sfxVolume;
        bgmVolumeSlider.value = bgmVolume;
        gammaSlider.value = gammaValue;

        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        gammaSlider.onValueChanged.AddListener(SetGamma);

        saveButton.onClick.AddListener(SaveOptions);
        cancelButton.onClick.AddListener(CancelOptions);

        OptionsPanel.SetActive(false); // 초기에는 설정 메뉴를 숨깁니다.
    }

    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
    }

    private void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        // 효과음 볼륨 조절 로직 추가
    }

    private void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        // 배경음 볼륨 조절 로직 추가
    }

    private void SetGamma(float gamma)
    {
        gammaValue = gamma;
        // 감마값 조절 로직 추가
    }

    private void SaveOptions()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume);
        PlayerPrefs.SetFloat("GammaValue", gammaValue);
        PlayerPrefs.Save();
    }

    private void CancelOptions()
    {
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        gammaSlider.value = PlayerPrefs.GetFloat("GammaValue", 1.0f);
    }

    private void LoadOptions()
    {
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        gammaValue = PlayerPrefs.GetFloat("GammaValue", 1.0f);
    }
}