using UnityEngine;

public class PuzzleRandomizer : MonoBehaviour
{
    public GameObject[] puzzlePieces;      // Arreglo con las piezas del puzzle
    public float minDistance = 2f;         // Distancia mínima desde la cámara
    public float maxDistance = 10f;        // Distancia máxima frente a la cámara
    public float minX = -5f;               // Rango mínimo en el eje X para las posiciones
    public float maxX = 5f;                // Rango máximo en el eje X
    public float minZ = -5f;               // Rango mínimo en el eje Z para las posiciones
    public float maxZ = 5f;                // Rango máximo en el eje Z

    private Camera mainCamera;              // Cámara principal de la escena

    void Start()
    {
        mainCamera = Camera.main;          // Asignar la cámara principal
        RandomizePuzzlePieces();           // Llamar a la función para aleatorizar las posiciones
    }

    // Función para aleatorizar las posiciones de las piezas
    private void RandomizePuzzlePieces()
    {
        foreach (GameObject piece in puzzlePieces)
        {
            // Generar una posición aleatoria frente a la cámara
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            float randomDistance = Random.Range(minDistance, maxDistance);

            // Calcular la posición en el espacio global
            Vector3 randomPosition = mainCamera.transform.position + mainCamera.transform.forward * randomDistance;
            randomPosition.x += randomX;  // Agregar un desplazamiento aleatorio en el eje X
            randomPosition.z += randomZ;  // Agregar un desplazamiento aleatorio en el eje Z
            randomPosition.y = 0f;        // Asegurarse de que las piezas estén en el suelo (Y = 0)

            // Colocar la pieza en la nueva posición
            piece.transform.position = randomPosition;

            // Si las piezas son hijos de algún objeto, asegúrate de usar la posición global
            piece.transform.position = randomPosition;
        }
    }
}
