using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class CambioEscenaDerrota : MonoBehaviour
{
    [Header("Referencias")]
    public GameResult gameResult;
    public RescueSystem rescueSystem;

    [Header("Configuración de Escena")]
    [Tooltip("Escribe el nombre exacto de la escena a la que quieres ir.")]
    public string nombreEscenaDerrota = "MenuPrincipal";

    private bool cambiandoEscena = false;

    private void Update()
    {
        // Si ya estamos cambiando de escena, no hacemos nada más para evitar errores
        if (cambiandoEscena) return;

        // Condición 1: El dinero es menor a -100
        bool sinDinero = gameResult.dinero < -100;

        // Condición 2: Se usaron las 5 ayudas
        // Como 'ayudaActual' suma 1 cada vez que se usa una, llegará a 5 cuando se usen todas.
        bool sinAyudas = rescueSystem.ObtenerAyudaActual() >= 5;

        // Si ambas condiciones se cumplen, cambiamos de escena
        if (sinDinero && sinAyudas)
        {
            cambiandoEscena = true; // Previene que se cargue la escena múltiples veces en el Update
            CambiarEscena();
        }
    }


    void CambiarEscena()
    {
        Debug.Log("¡Condiciones cumplidas! Cambiando de escena...");
        SceneManager.LoadScene(nombreEscenaDerrota);
    }
}