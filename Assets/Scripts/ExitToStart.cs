using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToStart : MonoBehaviour
{
    // Método que será llamado cuando se presione el botón de salir
    public void GoToStart()
    {
        SceneManager.LoadScene("HomeScreen");  // Asegúrate de que "MainMenu" es el nombre correcto de la escena de menú principal
    }
}
