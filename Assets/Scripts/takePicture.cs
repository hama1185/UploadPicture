using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class takePicture : MonoBehaviour
{
    public bool onceFlag = false;
    public RenderTexture CamTex;
    UploadS3 uploadS3;
    void Start()
    {
        onceFlag = false;
        uploadS3 = GetComponent<UploadS3>();
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
        // OSによって変える
        File.WriteAllBytes(Application.dataPath + "/CameraView.png", bytes);
        if(!onceFlag){
            uploadS3.upload();
            onceFlag = true;
        }        
    }
}
