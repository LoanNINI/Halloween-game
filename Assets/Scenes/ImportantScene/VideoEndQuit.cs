using UnityEngine;
using UnityEngine.Video;

public class VideoEndQuit : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished; // ลงทะเบียนอีเวนต์เมื่อวิดีโอเล่นจบ
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // ออกจากเกม
        Application.Quit();

        // สำหรับการทดสอบใน Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // หยุดการเล่นใน Unity Editor
        #endif
    }
}
