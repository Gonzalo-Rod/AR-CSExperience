using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class ObjectClickHandler : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Objeto de texto donde aparecerá el mensaje
    public string laptopMessage = "Es el dispositivo donde se desarrollan y prueban algoritmos, se crea software y se analizan datos, demostrando cómo la tecnología puede empoderar a los individuos para resolver problemas y generar innovación."; // Mensaje para la laptop
    public string chipMessage = "¡Hiciste clic en el chip!"; // Mensaje para el chip
    public string serverMessage = "¡Hiciste clic en el server!"; // Mensaje para el server
    public string nubeMessage = "¡Hiciste clic en la nube!"; // Mensaje para la nube
    public string futMessage = "¡Hiciste clic en la interfaz futurista!"; // Mensaje para la interfaz futurista

    public ParticleSystem confettiEffect; // Sistema de partículas que aparecerá al hacer clic

    void Start()
    {
        if (confettiEffect == null)
        {
            Debug.LogWarning("No hay un Particle System asignado para el efecto de confeti.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic del ratón
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Si el raycast golpea un collider
            {
                // Verifica si el objeto tiene la etiqueta "Laptop"
                if (hit.transform.CompareTag("Laptop")) // Etiqueta en lugar de nombre
                {
                    messageText.text = laptopMessage; // Cambia el texto al mensaje de la laptop
                    PlayConfettiEffect(); // Activa el efecto de confeti
                }
                // Verifica si el objeto tiene la etiqueta "Chip"
                else if (hit.transform.CompareTag("Chip")) // Etiqueta en lugar de nombre
                {
                    messageText.text = chipMessage; // Cambia el texto al mensaje del chip
                    PlayConfettiEffect(); // Activa el efecto de confeti
                }
                // Verifica si el objeto tiene la etiqueta "Server"
                else if (hit.transform.CompareTag("Server")) // Etiqueta para el server
                {
                    messageText.text = serverMessage; // Cambia el texto al mensaje del server
                    PlayConfettiEffect(); // Activa el efecto de confeti
                }
                // Verifica si el objeto tiene la etiqueta "Nube"
                else if (hit.transform.CompareTag("Nube")) // Etiqueta para la nube
                {
                    messageText.text = nubeMessage; // Cambia el texto al mensaje de la nube
                    PlayConfettiEffect(); // Activa el efecto de confeti
                }
                // Verifica si el objeto tiene la etiqueta "Fut"
                else if (hit.transform.CompareTag("Fut")) // Etiqueta para la interfaz futurista
                {
                    messageText.text = futMessage; // Cambia el texto al mensaje de la interfaz futurista
                    PlayConfettiEffect(); // Activa el efecto de confeti
                }
            }
        }
    }

    // Método para reproducir el sistema de partículas
    void PlayConfettiEffect()
    {
        if (confettiEffect != null)
        {
            confettiEffect.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            confettiEffect.Play(); // Activa el sistema de partículas
        }
    }
}
