using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escenas

public class ExitToDM : MonoBehaviour
{
    // M�todo que ser� llamado cuando se presione el bot�n de salir
    public void GoToDM()
    {
        SceneManager.LoadScene("GameScreen");  // Aseg�rate de que "MainMenu" es el nombre correcto de la escena de men� principal
    }
}
