using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Webカメラ
public class Camera : MonoBehaviour
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
    }

}
