using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Webカメラ
public class WebCamScreen3 : MonoBehaviour
{
    private static int INPUT_SIZE = 256;
    private static int FPS = 30;

    // UI
    RawImage rawImage;
    WebCamTexture webCamTexture;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    // スタート時に呼ばれる
    void Start ()
    {
        // Webカメラの開始
        this.rawImage = GetComponent<RawImage>();
        this.webCamTexture = new WebCamTexture(INPUT_SIZE, INPUT_SIZE, FPS);
        this.rawImage.texture = this.webCamTexture;
        this.webCamTexture.Play();
        Invoke(nameof(ScreenShot), 10f);
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(Camera), 10f);
        Invoke(nameof(Camera2), 6f);
    }

    void ScreenShot()
    {
        CaptureScreenShot("ScreenShot3.png");
    }
    void Camera(){
      audioSource.PlayOneShot(sound1);
    }
    void Camera2(){
      audioSource.PlayOneShot(sound2);
    }
    private void CaptureScreenShot(string filePath)
    {
        ScreenCapture.CaptureScreenshot(filePath);
    }

}
