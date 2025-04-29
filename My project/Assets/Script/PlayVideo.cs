using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    public GameObject videoScreen;       // RawImage 显示幕布
    public VideoPlayer videoPlayer;      // VideoPlayer 播放器

    private bool hasSubscribed = false;  // 防止重复绑定事件

    public void PlayVideo()
    {
        if (videoScreen == null || videoPlayer == null)
        {
            Debug.LogWarning("❗videoScreen 或 videoPlayer 未绑定！");
            return;
        }

        videoScreen.SetActive(true);
        videoPlayer.Stop();       // 保险起见，先 Stop 一次
        videoPlayer.Play();

        // 防止多次重复绑定事件（会导致多次触发）
        if (!hasSubscribed)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
            hasSubscribed = true;
        }

        Debug.Log("▶️ 播放视频开始");
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("✅ 视频播放完毕，关闭屏幕");
        videoScreen.SetActive(false);
    }
}
