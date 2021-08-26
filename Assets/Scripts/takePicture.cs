using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class takePicture : MonoBehaviour
{
    public RenderTexture CamTex;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void onclickTakeButton(){

        Texture2D tex = new Texture2D(CamTex.width, CamTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = CamTex;
        tex.ReadPixels(new Rect(0, 0, CamTex.width, CamTex.height), 0, 0);
        tex.Apply();

        byte[] bytes = tex.EncodeToPNG();
        File.WriteAllBytes("CameraView.png", bytes);
    }
}
