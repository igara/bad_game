using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Stage1Scene_MovieScript : MonoBehaviour
{
    void Awake()
    {
        VideoPlayer videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.url =
            System
                .IO
                .Path
                .Combine(Application.streamingAssetsPath, "ojisan_bgm.mp4");
        videoPlayer.Play();
    }
}
