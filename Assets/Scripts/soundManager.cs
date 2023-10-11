using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioClip game_bgm;

    private float currentVolume = 0.5f;
   
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        // 초기 음량 설정
        _bgmSource.volume = currentVolume;

    }
    private void PlayBGM(AudioClip bgm)
    {
        _bgmSource.clip = bgm;
        _bgmSource.loop = true;
        _bgmSource.Play();

    }

    private void Start()
    {
        PlayBGM(game_bgm);
    }

}
