using UnityEngine;
using System.Collections.Generic;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr _instance;

    public AudioClip[] bgms;
    public AudioClip[] fxs;

    public AudioSource bgm;
    public AudioSource fx;

    private Dictionary<string, AudioClip> bgmDict;
    private Dictionary<string, AudioClip> fxDict;

    private void Awake()
    {
        _instance = this;
        bgmDict = new Dictionary<string, AudioClip>();
        fxDict = new Dictionary<string, AudioClip>();
        InitAudios();
        DontDestroyOnLoad(gameObject);
    }

    void InitAudios()
    {
        for (int i = 0; i < bgms.Length; i++)
        {
            bgmDict.Add(bgms[i].name, bgms[i]);
        }

        for (int i = 0; i < fxs.Length; i++)
        {
            fxDict.Add(fxs[i].name, fxs[i]);
        }
    }

    /// <summary>
    /// 关闭BGM
    /// </summary>
    public void OffBgm()
    {
        if (bgm != null)
            bgm.Pause();
    }

    public void PlayCurrentBgm()
    {
        if (bgm.clip != null)
        {
            bgm.Play();
        }
    }

    /// <summary>
    /// 关闭BGM
    /// </summary>
    public void StopBGM()
    {
        if (bgm != null)
            bgm.Stop();
    }

    /// <summary>
    /// 播放BGM
    /// </summary>
    /// <param name="clipName"></param>
    public void PlayBGM(string clipName)
    {
        if (bgmDict.ContainsKey(clipName))
        {
            bgm.clip = bgmDict[clipName];
            bgm.Play();
            bgm.loop = true;
        }
    }

    public void RestBGM(string clipName)
    {
        bgm.Stop();
        if (bgmDict.ContainsKey(clipName))
        {
            bgm.clip = bgmDict[clipName];
            bgm.Play();
            bgm.loop = true;
        }
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="clipName"></param>
    public void PlayFx(string clipName)
    {
        if (fxDict.ContainsKey(clipName))
        {
            fx.clip = fxDict[clipName];
            fx.Play();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (ScenesMgr.Instance.LevelInfo == null|| level == 2)
        {
            PlayBGM("BGM");
        }
        else
        {
            string str = System.Text.RegularExpressions.Regex.Replace(ScenesMgr.Instance.LevelInfo, @"[^0-9]+", "");

            char[] temp = str.ToCharArray();
            int level1 = int.Parse(temp[1].ToString());
            PlayBGM("BGM" + level1);
        }

        if (level == 3)
        {
            StopBGM();
        }
    }
}
