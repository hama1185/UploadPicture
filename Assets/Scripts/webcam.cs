using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{
    public RenderTexture Capture;

    WebCamTexture webCamTexture;

    void Start () {
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
	}
	
	void Update (){
        // ビットマップの転送
        Graphics.Blit(webCamTexture, Capture);
	}
}