using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TitleScene_MovieScript : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private AudioSource bgm;

    private bool isSkip = false;

    void Awake()
    {
        canvas.SetActive(false);
        videoPlayer.url =
            System
                .IO
                .Path
                .Combine(Application.streamingAssetsPath, "Title.mp4");
        videoPlayer.loopPointReached += LoopPointReached;
        videoPlayer.Play();
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        canvas.SetActive(true);
        bgm.Play();
    }

    void Update()
    {
        if (!isSkip && Input.GetMouseButtonUp(0))
        {
            isSkip = true;
            videoPlayer.Pause();

            canvas.SetActive(true);
            bgm.Play();
        }
    }
}
