using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToStart : MonoBehaviour
{
    // M�todo que ser� llamado cuando se presione el bot�n de salir
    public void GoToStart()
    {
        SceneManager.LoadScene("HomeScreen");  // Aseg�rate de que "MainMenu" es el nombre correcto de la escena de men� principal
    }
}
