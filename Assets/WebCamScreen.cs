using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Webカメラ
public class WebCamScreen : MonoBehaviour
{
    private static int INPUT_SIZE = 256;
    private static int FPS = 30;
    private float step_time;//シーン移動用

    // UI
    RawImage rawImage;
    WebCamTexture webCamTexture;

    // スタート時に呼ばれる
    void Start ()
    {
        // Webカメラの開始
        this.rawImage = GetComponent<RawImage>();
        this.webCamTexture = new WebCamTexture(INPUT_SIZE, INPUT_SIZE, FPS);
        this.rawImage.texture = this.webCamTexture;
        this.webCamTexture.Play();
        Invoke(nameof(ScreenShot), 10f);
        step_time = 0.0f;
    }

    void ScreenShot()
    {
        CaptureScreenShot("ScreenShot1.png");
    }

    private void CaptureScreenShot(string filePath)
    {
        ScreenCapture.CaptureScreenshot(filePath);
    }
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移（scene2へ移動）
        if (step_time >= 12.0f)
        {
            SceneManager.LoadScene("Screen2");
        }
    }
}
