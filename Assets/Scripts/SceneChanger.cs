using UnityEngine;
using UnityEngine.SceneManagement; // Es fundamental incluir esta librería

public class SceneChanger : MonoBehaviour
{
    // Esta función recibe el nombre de la escena a la que quieres ir
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Opcional: Una función extra por si también necesitas un botón de "Salir"
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado (Esto solo se ve en el editor)");
    }
}