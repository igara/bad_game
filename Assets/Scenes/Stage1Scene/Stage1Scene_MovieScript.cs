using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class Stage1Scene_MovieScript : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private TMP_Text bgmText;

    private List<string> bgmList = new List<string>
    {
        "bgm_1.mp4",
        "bgm_2.mp4",
    };

    void Awake()
    {
        videoPlayer.loopPointReached += LoopPointReached;
        UpdateBGM();
    }

    private void UpdateBGM()
    {
        string randomBGM = bgmList[Random.Range (0, bgmList.Count)];
        videoPlayer.url =
            System
                .IO
                .Path
                .Combine(Application.streamingAssetsPath, randomBGM);
        if (randomBGM == "bgm_1.mp4")
        {
            bgmText.text = "安全地帯\nマスカレード";
        }
        else if (randomBGM == "bgm_2.mp4")
        {
            bgmText.text = "安全地帯\n真夜中すぎの恋";
        }

        videoPlayer.Play();
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        UpdateBGM();
    }
}
