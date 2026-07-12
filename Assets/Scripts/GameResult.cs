using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameResult : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_Text resultadoTexto;
    public TMP_Text dineroTexto;

    [Header("Dinero")]
    public int dineroInicial = 0;
    public int dineroPorVictoria = 100;
    public int dineroPorDerrota = 50;

    [Header("Probabilidades")]
    [Range(0, 100)]
    public int probabilidadDeGanar = 50;

    public int dinero;
    public Animator resultadoAnimator;
    public RescueSystem rescueSystem;

    [Header("Botón")]
    public Button jugarButton;

    private bool jugando = false;
    private bool gano = false;

    void Start()
    {
        dinero = dineroInicial;
        ActualizarDinero();
        resultadoTexto.text = "";
    }
    public void Jugar()
    {
        if (jugando)
            return;

        jugando = true;
        jugarButton.interactable = false;

        int numero = Random.Range(0, 100);

        if (numero < probabilidadDeGanar)
        {
            resultadoAnimator.Play("Ganar", 0, 0f);
            Invoke(nameof(FinalizarVictoria), 1f);
        }
        else
        {
            resultadoAnimator.Play("Perder", 0, 0f);
            Invoke(nameof(FinalizarDerrota), 1f);
        }
    }
    public void ActualizarDinero()
    {
        dineroTexto.text = "Dinero: " + dinero;

        if (rescueSystem != null)
            rescueSystem.RevisarAyuda();
    }
    void FinalizarVictoria()
    {
        dinero += dineroPorVictoria;
        resultadoTexto.text = "¡Ganaste!";
        jugarButton.interactable = true;
        jugando = false;
        ActualizarDinero();
    }

    void FinalizarDerrota()
    {
        dinero -= dineroPorDerrota;
        resultadoTexto.text = "Perdiste";
        rescueSystem.RevisarAyuda();
        jugarButton.interactable = true;
        jugando = false;
        ActualizarDinero(); 
    }
    
}
