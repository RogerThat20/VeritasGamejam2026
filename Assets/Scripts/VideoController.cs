using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna el VideoPlayer desde el inspector
    public RawImage rawImage;       // Asigna el RawImage desde el inspector

    void Start()
    {
        // Vinculamos la textura del VideoPlayer al RawImage
        rawImage.texture = videoPlayer.targetTexture;

        // Iniciamos la reproducción
        videoPlayer.Play();
    }


}