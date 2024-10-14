using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    private float initialDistance;       // Distancia inicial entre los toques
    private Vector3 initialScale;        // Tamaño inicial del objeto
    public float zoomSpeed = 0.01f;      // Velocidad del zoom (ajustable)

    void Update()
    {
        // Si hay más de un toque en la pantalla, detecta el gesto de pinch
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Calcula la distancia entre los dos toques
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);

            // Si los toques acaban de comenzar, registra la distancia inicial y el tamaño inicial del objeto
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialDistance = currentDistance;
                initialScale = transform.localScale;
            }
            else
            {
                // Calcula el factor de escala basado en el cambio de distancia
                if (Mathf.Approximately(initialDistance, 0)) return;

                float factor = currentDistance / initialDistance;

                // Aplica el factor de escala al objeto
                transform.localScale = initialScale * factor;

                // Limitar el tamaño mínimo y máximo
                transform.localScale = new Vector3(
                    Mathf.Clamp(transform.localScale.x, 0.5f, 10f),
                    Mathf.Clamp(transform.localScale.y, 0.5f, 10f),
                    Mathf.Clamp(transform.localScale.z, 0.5f, 10f)
                );
            }
        }
    }
}
