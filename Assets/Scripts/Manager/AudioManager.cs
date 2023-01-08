using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip click, die, go, hurt, money, won;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("AudioManager instance not found");

            return instance;
        }
    }
    void Awake()
    {
        if (instance)
            Destroy(instance.gameObject);
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void PlayClick()
    {
        source.PlayOneShot(click);
    }
    public void PlayDie()
    {
        source.PlayOneShot(die,0.8f);
    }
    public void PlayHurt()
    {
        source.PlayOneShot(hurt,0.8f);
    }
    public void PlayGameOver()
    {
        source.PlayOneShot(go);
    }
    public void PlayWon()
    {
        source.PlayOneShot(won);
    }
    public void PlayMoney()
    {
        source.PlayOneShot(money);
    }

}
