using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public PuzzlePiece[] puzzlePieces;       // Arreglo de todas las piezas del puzzle
    public AudioSource successSound;         // Sonido de éxito al completar el puzzle
    public AudioSource failSound;            // Sonido que se reproducirá si el jugador falla
    [SerializeField] private TextMeshProUGUI puzzleCompletedText;         // Texto que aparece cuando se completa el puzzle
    [SerializeField] private TextMeshProUGUI timerText;                   // Texto para mostrar el temporizador
    [SerializeField] private TextMeshProUGUI failedText;                  // Texto que aparece cuando el jugador falla
    public ParticleSystem confettiEffect;    // Efecto de confeti
    public Button retryButton;
    public float puzzleTimeLimit = 300f;     // Tiempo límite para completar el puzzle (en segundos, 300s = 5 minutos)

    private bool puzzleCompleted = false;    // Para verificar si el puzzle ya fue completado
    private float timeRemaining;             // Tiempo restante para completar el puzzle
    private bool isGameOver = false;         // Para verificar si el tiempo se ha acabado

    void Start()
    {
        // Inicializa el tiempo restante con el límite dado
        timeRemaining = puzzleTimeLimit;

        // Asegurarse de que el texto de completado y fallado esté desactivado al inicio
        puzzleCompletedText.gameObject.SetActive(false);
        failedText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        retryButton.onClick.AddListener(RestartGame);

        // Mostrar el temporizador al inicio
        UpdateTimerText();
    }

    void Update()
    {
        // Si el puzzle ya se completó o el tiempo se acabó, no hacemos nada
        if (puzzleCompleted || isGameOver)
            return;

        // Actualizamos el tiempo restante
        timeRemaining -= Time.deltaTime;

        // Actualizar el texto del temporizador
        UpdateTimerText();

        // Si el tiempo se ha agotado, finaliza el juego
        if (timeRemaining <= 0)
        {
            GameOver();
        }

        // Verifica si el puzzle está completo
        if (IsPuzzleComplete())
        {
            OnPuzzleComplete();
        }
    }

    // Método para actualizar el texto del temporizador
    private void UpdateTimerText()
    {
        // Convierte el tiempo restante en minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualizar el texto con formato "mm:ss"
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Método para verificar si todas las piezas están en su posición correcta
    private bool IsPuzzleComplete()
    {
        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (!piece.IsInCorrectPosition())  // Si alguna pieza no está en su lugar correcto
            {
                return false;                  // El puzzle no está completo
            }
        }
        return true;  // Todas las piezas están en su lugar, puzzle completo
    }

    // Método que se llama cuando el puzzle se completa
    private void OnPuzzleComplete()
    {
        puzzleCompleted = true;  // Marcar que el puzzle está completado

        // Reproducir el sonido de éxito
        if (successSound != null)
        {
            successSound.Play();
        }

        // Mostrar el texto de "Puzzle Completado"
        if (puzzleCompletedText != null)
        {
            puzzleCompletedText.gameObject.SetActive(true);
        }

        // Activar el efecto de confeti
        if (confettiEffect != null)
        {
            confettiEffect.Play();
        }

        Debug.Log("¡Puzzle completado!");
    }

    // Método que se llama cuando el tiempo se acaba
    private void GameOver()
    {
        isGameOver = true;  // Marcar que el juego ha terminado

        // Detener todas las piezas del puzzle
        foreach (PuzzlePiece piece in puzzlePieces)
        {
            piece.enabled = false;  // Desactivar los scripts de las piezas para que no puedan moverse
        }

        // Mostrar el mensaje de "Fallaste"
        if (failedText != null)
        {
            failedText.gameObject.SetActive(true);
        }

        // Reproducir el sonido de fallo
        if (failSound != null)
        {
            failSound.Play();
        }

        if (retryButton != null)
        {
            retryButton.gameObject.SetActive(true);
        }

        Debug.Log("¡Tiempo agotado! Puzzle fallido.");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reiniciar la escena actual
    }
}
