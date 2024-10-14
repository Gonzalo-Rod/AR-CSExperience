using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escenas

public class ExitToDM : MonoBehaviour
{
    // Método que será llamado cuando se presione el botón de salir
    public void GoToDM()
    {
        SceneManager.LoadScene("GameScreen");  // Asegúrate de que "MainMenu" es el nombre correcto de la escena de menú principal
    }
}
