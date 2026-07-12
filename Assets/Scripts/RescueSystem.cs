using System;
using TMPro;
using Unity.AppUI.Redux;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video; // Esencial para reproducir videos

public class RescueSystem : MonoBehaviour
{
    [Header("Botones de ayuda (en orden)")]
    public Button[] botonesAyuda;

    [Header("Dinero que entrega cada botón")]
    public int[] dineroAyuda = new int[5];

    private int ayudaActual = 0;

    [Header("Quinto botón")]
    public Image imagenBoton5;

    public Color colorBloqueado = new Color(0.2f, 0.2f, 0.2f, 1f);
    public Color colorDesbloqueado = Color.white;
    public GameResult gameResult;

    [Header("Sistema de Video")]
    public VideoClip[] videosAyuda = new VideoClip[5]; // Arreglo para los 5 videos distintos
    public GameObject videoPlayer; // El componente que reproduce el video
    public GameObject panelVideo; // El panel UI que mostrará el video y el botón de cerrar
    public bool isPlaying = false;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            botonesAyuda[i].gameObject.SetActive(false);
            botonesAyuda[i].interactable = false;
        }

        botonesAyuda[4].gameObject.SetActive(true);
        botonesAyuda[4].interactable = false;

        imagenBoton5.color = colorBloqueado;

        // Asegurarnos de que el panel de video empiece apagado al iniciar el juego
        if (panelVideo != null)
        {
            panelVideo.SetActive(false);
        }
        isPlaying = true;
    }

    public void RevisarAyuda()
    {
        if (gameResult == null)
            return;

        if (gameResult.dinero >= 0)
            return;

        if (ayudaActual >= botonesAyuda.Length)
            return;

        if (ayudaActual < 4)
        {
            botonesAyuda[ayudaActual].gameObject.SetActive(true);
            botonesAyuda[ayudaActual].interactable = true;
        }
        else
        {
            botonesAyuda[4].interactable = true;
            imagenBoton5.color = colorDesbloqueado;
        }

        // Reproducir el video justo en el momento en que se habilita el botón
        ReproducirVideo(ayudaActual);
    }

    // Función interna para reproducir el video correspondiente
    private void ReproducirVideo(int indice)
    {
        // Validamos que existan las referencias y el video para evitar errores
        if (videoPlayer != null && panelVideo != null && videosAyuda.Length > indice && videosAyuda[indice] != null && !isPlaying)
        {
             // Asignamos el video distinto
            panelVideo.SetActive(true); // Encendemos el panel visual
            videoPlayer.SetActive(true); // Le damos Play
        }
    }

    // Esta es la función que el Botón de Cerrar Video va a ejecutar
    public void CerrarVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.SetActive(false); // Detenemos la reproducción
        }
        if (panelVideo != null)
        {
            panelVideo.SetActive(false); // Apagamos el panel
        }
    }

    public void UsarAyuda1() { UsarAyuda(0); }
    public void UsarAyuda2() { UsarAyuda(1); }
    public void UsarAyuda3() { UsarAyuda(2); }
    public void UsarAyuda4() { UsarAyuda(3); }
    public void UsarAyuda5() { UsarAyuda(4); }

    void UsarAyuda(int indice)
    {
        if (indice != ayudaActual)
            return;

        gameResult.dinero += dineroAyuda[indice];

        gameResult.ActualizarDinero();

        botonesAyuda[indice].interactable = false;

        if (indice < 4)
        {
            botonesAyuda[indice].gameObject.SetActive(false);
        }
        else
        {
            imagenBoton5.color = colorBloqueado;
        }

        ayudaActual++;

        RevisarAyuda();
    }
}