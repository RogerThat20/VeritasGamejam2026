using System;
using TMPro;
using Unity.AppUI.Redux;
using UnityEngine;
using UnityEngine.UI; // Usamos esto para el componente Image

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

    [Header("Sistema de Imágenes")]
    public Sprite[] imagenesAyuda = new Sprite[5]; // Arreglo para las 5 imágenes distintas
    public Image visorImagen; // El componente UI que mostrará la imagen en pantalla
    public GameObject panelImagen; // El panel UI que contiene la imagen y el botón de cerrar

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

        // Asegurarnos de que el panel de la imagen empiece apagado al iniciar el juego
        if (panelImagen != null)
        {
            panelImagen.SetActive(false);
        }
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

        // Mostrar la imagen justo en el momento en que se habilita el botón
        MostrarImagen(ayudaActual);
    }

    // Función interna para mostrar la imagen correspondiente
    private void MostrarImagen(int indice)
    {
        // Validamos que existan las referencias y el sprite para evitar errores
        if (visorImagen != null && panelImagen != null && imagenesAyuda.Length > indice && imagenesAyuda[indice] != null)
        {
            visorImagen.sprite = imagenesAyuda[indice]; // Cambiamos la imagen
            panelImagen.SetActive(true); // Encendemos el panel visual

            // obtenemos el animation controller de este objeto
            Animator animator = panelImagen.GetComponent<Animator>();

            // configuramos que se ejecute la animacion con el parametro indice
            animator.SetInteger("Indice", indice);

            // reproducimos la animacion
            //animator.Play();
            animator.StartPlayback();
        }
    }

    // Esta es la función que el Botón de Cerrar va a ejecutar
    public void CerrarImagen()
    {
        if (panelImagen != null)
        {
            panelImagen.SetActive(false); // Apagamos el panel
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