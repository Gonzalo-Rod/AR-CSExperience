using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public PuzzlePiece[] puzzlePieces;       // Arreglo de todas las piezas del puzzle
    public AudioSource successSound;         // Sonido de �xito al completar el puzzle
    public AudioSource failSound;            // Sonido que se reproducir� si el jugador falla
    [SerializeField] private TextMeshProUGUI puzzleCompletedText;         // Texto que aparece cuando se completa el puzzle
    [SerializeField] private TextMeshProUGUI timerText;                   // Texto para mostrar el temporizador
    [SerializeField] private TextMeshProUGUI failedText;                  // Texto que aparece cuando el jugador falla
    public ParticleSystem confettiEffect;    // Efecto de confeti
    public Button retryButton;
    public float puzzleTimeLimit = 300f;     // Tiempo l�mite para completar el puzzle (en segundos, 300s = 5 minutos)

    private bool puzzleCompleted = false;    // Para verificar si el puzzle ya fue completado
    private float timeRemaining;             // Tiempo restante para completar el puzzle
    private bool isGameOver = false;         // Para verificar si el tiempo se ha acabado

    void Start()
    {
        // Inicializa el tiempo restante con el l�mite dado
        timeRemaining = puzzleTimeLimit;

        // Asegurarse de que el texto de completado y fallado est� desactivado al inicio
        puzzleCompletedText.gameObject.SetActive(false);
        failedText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        retryButton.onClick.AddListener(RestartGame);

        // Mostrar el temporizador al inicio
        UpdateTimerText();
    }

    void Update()
    {
        // Si el puzzle ya se complet� o el tiempo se acab�, no hacemos nada
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

        // Verifica si el puzzle est� completo
        if (IsPuzzleComplete())
        {
            OnPuzzleComplete();
        }
    }

    // M�todo para actualizar el texto del temporizador
    private void UpdateTimerText()
    {
        // Convierte el tiempo restante en minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualizar el texto con formato "mm:ss"
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // M�todo para verificar si todas las piezas est�n en su posici�n correcta
    private bool IsPuzzleComplete()
    {
        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (!piece.IsInCorrectPosition())  // Si alguna pieza no est� en su lugar correcto
            {
                return false;                  // El puzzle no est� completo
            }
        }
        return true;  // Todas las piezas est�n en su lugar, puzzle completo
    }

    // M�todo que se llama cuando el puzzle se completa
    private void OnPuzzleComplete()
    {
        puzzleCompleted = true;  // Marcar que el puzzle est� completado

        // Reproducir el sonido de �xito
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

        Debug.Log("�Puzzle completado!");
    }

    // M�todo que se llama cuando el tiempo se acaba
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

        Debug.Log("�Tiempo agotado! Puzzle fallido.");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reiniciar la escena actual
    }
}
