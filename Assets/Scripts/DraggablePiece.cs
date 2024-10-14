using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private bool isDragging = false;        // Para saber si la pieza está siendo arrastrada
    private Vector3 offset;                 // La diferencia entre el punto tocado y la posición de la pieza
    private Camera mainCamera;              // Referencia a la cámara principal

    // Definimos la posición correcta de la pieza
    public Vector3 correctPosition;
    public float snapThreshold = 0.5f;      // Distancia mínima para encajar la pieza en su lugar

    // Pieza transparente de referencia
    public GameObject transparentPiece;

    // Sonido de éxito
    public AudioSource successSound;  // Referencia al componente AudioSource para reproducir el sonido

    private bool isSnapped = false;         // Para verificar si la pieza ya está encajada

    private int ignoreGuideLayerMask;

    private void Start()
    {
        mainCamera = Camera.main;           // Asignar la cámara principal

        ignoreGuideLayerMask = ~LayerMask.GetMask("GuidePiece");
    }

    void Update()
    {
        if (isSnapped) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  // Obtener el toque de pantalla

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ignoreGuideLayerMask))
                {
                    if (hit.transform == this.transform)  // Verificar si el toque fue en la pieza
                    {
                        isDragging = true;               // Comienza a arrastrar la pieza
                        offset = this.transform.position - hit.point;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    this.transform.position = hit.point + offset;  // Mueve la pieza a la nueva posición del toque
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;  // Finaliza el arrastre cuando se levanta el dedo

                // Verifica si la pieza debe encajarse en su posición correcta
                SnapToCorrectPosition();
            }
        }
    }

    // Método para encajar la pieza en su posición correcta si está lo suficientemente cerca
    private void SnapToCorrectPosition()
    {
        // Si la pieza ya está encajada, no hacemos nada
        if (isSnapped) return;

        float distance = Vector3.Distance(this.transform.position, correctPosition);

        // Verifica si la pieza está lo suficientemente cerca de la posición correcta
        if (distance < snapThreshold)
        {
            // Encaja la pieza en su lugar
            this.transform.position = correctPosition;

            // Reproduce el sonido de éxito si está asignado
            if (successSound != null)
            {
                successSound.Play();
            }

            // Elimina la pieza transparente o la desactiva
            if (transparentPiece != null)
            {
                Destroy(transparentPiece);  // O puedes usar transparentPiece.SetActive(false) si prefieres solo desactivarla
            }

            isSnapped = true;  // Marca la pieza como encajada

        }
    }

    // Método para verificar si la pieza está en su lugar correcto
    public bool IsInCorrectPosition()
    {
        float distance = Vector3.Distance(this.transform.position, correctPosition);
        return distance < snapThreshold;
    }
}
