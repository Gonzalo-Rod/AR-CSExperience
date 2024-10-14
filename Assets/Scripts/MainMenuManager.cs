using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escenas
using UnityEngine.UI;              // Para poder referenciar UI components

public class MainMenuManager : MonoBehaviour
{
    // Métodos que se llamarán al hacer clic en los botones
    public void Load9PiecePuzzle()
    {
        SceneManager.LoadScene("ARPuzzle3x3");  // Reemplaza con el nombre de tu escena de 9 piezas
    }

    public void Load16PiecePuzzle()
    {
        SceneManager.LoadScene("ARPuzzle4x4");  // Reemplaza con el nombre de tu escena de 16 piezas
    }
}
