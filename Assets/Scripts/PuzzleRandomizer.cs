using UnityEngine;

public class PuzzleRandomizer : MonoBehaviour
{
    public GameObject[] puzzlePieces;      // Arreglo con las piezas del puzzle
    public float minDistance = 2f;         // Distancia m�nima desde la c�mara
    public float maxDistance = 10f;        // Distancia m�xima frente a la c�mara
    public float minX = -5f;               // Rango m�nimo en el eje X para las posiciones
    public float maxX = 5f;                // Rango m�ximo en el eje X
    public float minZ = -5f;               // Rango m�nimo en el eje Z para las posiciones
    public float maxZ = 5f;                // Rango m�ximo en el eje Z

    private Camera mainCamera;              // C�mara principal de la escena

    void Start()
    {
        mainCamera = Camera.main;          // Asignar la c�mara principal
        RandomizePuzzlePieces();           // Llamar a la funci�n para aleatorizar las posiciones
    }

    // Funci�n para aleatorizar las posiciones de las piezas
    private void RandomizePuzzlePieces()
    {
        foreach (GameObject piece in puzzlePieces)
        {
            // Generar una posici�n aleatoria frente a la c�mara
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            float randomDistance = Random.Range(minDistance, maxDistance);

            // Calcular la posici�n en el espacio global
            Vector3 randomPosition = mainCamera.transform.position + mainCamera.transform.forward * randomDistance;
            randomPosition.x += randomX;  // Agregar un desplazamiento aleatorio en el eje X
            randomPosition.z += randomZ;  // Agregar un desplazamiento aleatorio en el eje Z
            randomPosition.y = 0f;        // Asegurarse de que las piezas est�n en el suelo (Y = 0)

            // Colocar la pieza en la nueva posici�n
            piece.transform.position = randomPosition;

            // Si las piezas son hijos de alg�n objeto, aseg�rate de usar la posici�n global
            piece.transform.position = randomPosition;
        }
    }
}
