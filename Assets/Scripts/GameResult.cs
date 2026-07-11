using UnityEngine;
using TMPro;

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

    private int dinero;

    void Start()
    {
        dinero = dineroInicial;
        ActualizarDinero();
        resultadoTexto.text = "";
    }

    public void Jugar()
    {
        int numero = Random.Range(0, 100);

        if (numero < probabilidadDeGanar)
        {
            // Gana
            dinero += dineroPorVictoria;
            resultadoTexto.text = "¡Ganaste!";
        }
        else
        {
            // Pierde
            dinero -= dineroPorDerrota;


            resultadoTexto.text = "Perdiste";
        }

        ActualizarDinero();
    }

    void ActualizarDinero()
    {
        dineroTexto.text = "Dinero: " + dinero.ToString("000");
    }
}
