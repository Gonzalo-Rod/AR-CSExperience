using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escenas

public class ExitToMenu : MonoBehaviour
{
    // Método que será llamado cuando se presione el botón de salir
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("VuforiaScreen");  // Asegúrate de que "MainMenu" es el nombre correcto de la escena de menú principal
    }
}
