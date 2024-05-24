using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgm;
    public AudioSource effect;
    public AudioClip[] bgmList;
    public AudioClip[] effectList;
    public AudioClip[] catList;

    public AudioSource player;
    public AudioSource cat;
    public AudioSource monster;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            bgm = transform.Find("BGM").GetComponent<AudioSource>();
            effect = transform.Find("Effect").GetComponent<AudioSource>();
            player = transform.Find("Player").GetComponent<AudioSource>();
            cat = transform.Find("Cat").GetComponent<AudioSource>();
            monster = transform.Find("Monster").GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerOn()
    {
        if (!player.isPlaying)
        {
            player.Play();
        }
    }

    public void PlayerOff()
    {
        player.Stop();
    }

    public void CatOn(int index)
    {
        cat.Stop();
        cat.clip = catList[index];
        cat.Play();
    }

    public void CatOff()
    {
        cat.Stop();
    }

    public void MonsterOn()
    {
        if (!monster.isPlaying)
        {
            monster.Play();
        }
    }

    public void MonsterOff()
    {
        monster.Stop();
    }

    public void PlayBGM(int index)
    {
        Debug.Log(bgm);
        Debug.Log(index);
        bgm.Stop();
        bgm.clip = bgmList[index];
        bgm.Play();
    }

    public void StopBGM()
    {
        if (bgm.isPlaying)
            bgm.Stop();
    }

    public void PlayEffect(int index)
    {
        effect.PlayOneShot(effectList[index]);
    }

    public void StopEffect()
    {
        effect.Stop();
    }
}