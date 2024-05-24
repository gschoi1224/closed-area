using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Play B G M");
        SoundManager.instance.PlayBGM(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        SoundManager.instance.PlayBGM(1);
    }
}
