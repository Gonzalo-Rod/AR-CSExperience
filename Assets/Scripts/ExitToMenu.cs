using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escenas

public class ExitToMenu : MonoBehaviour
{
    // M�todo que ser� llamado cuando se presione el bot�n de salir
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("VuforiaScreen");  // Aseg�rate de que "MainMenu" es el nombre correcto de la escena de men� principal
    }
}
