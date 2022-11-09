using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Webカメラ
public class WebCam : MonoBehaviour
{
    private static int INPUT_SIZE = 256;
    private static int FPS = 30;
    private float step_time;//シーン移動用

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
        Invoke(nameof(TakeShot), 10f);
        step_time = 0.0f;
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(Camera), 10f);
        Invoke(nameof(Camera2), 6f);
    }

    void TakeShot()
    {
        Texture tex = this.rawImage.texture;
        int w = tex.width;
        int h = tex.height;

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture rt = new RenderTexture(w, h, 32);

        Graphics.Blit(tex, rt);
        RenderTexture.active = rt;

        Texture2D result = new Texture2D(w, h, TextureFormat.RGBA32, false);
        result.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        result.Apply();
        RenderTexture.active = currentRT;

        GetComponent<MeshRenderer>().material.mainTexture = result;
    }
    void Camera(){
      audioSource.PlayOneShot(sound1);
    }

    void Camera2(){
      audioSource.PlayOneShot(sound2);
    }

    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移（scene2へ移動）
        if (step_time >= 12.0f)
        {
            SceneManager.LoadScene("Screen1");
        }
    }
}
