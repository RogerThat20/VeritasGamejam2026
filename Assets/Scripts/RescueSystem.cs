using System;
using TMPro;
using Unity.AppUI.Redux;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void UsarAyuda1()
    {
        UsarAyuda(0);
    }

    public void UsarAyuda2()
    {
        UsarAyuda(1);
    }

    public void UsarAyuda3()
    {
        UsarAyuda(2);
    }

    public void UsarAyuda4()
    {
        UsarAyuda(3);
    }

    public void UsarAyuda5()
    {
        UsarAyuda(4);
    }

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