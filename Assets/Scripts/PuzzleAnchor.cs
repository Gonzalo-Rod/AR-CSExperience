using Niantic.Lightship.AR;
using UnityEngine;

public class PlacePuzzleOnPlane : MonoBehaviour
{
    public GameObject puzzlePrefab;  // Prefab del rompecabezas
    private GameObject instantiatedPuzzle;  // Referencia al puzzle instanciado
    private Camera arCamera;  // Cámara AR principal

    void Start()
    {
        arCamera = Camera.main;
    }

    void Update()
    {
        // Usa explícitamente UnityEngine.Input para evitar ambigüedad
        if (UnityEngine.Input.touchCount > 0)
        {
            Touch touch = UnityEngine.Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Ray desde la pantalla hacia el mundo
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Verifica si hay un plano detectado donde se puede colocar el puzzle
                if (Physics.Raycast(ray, out hit))
                {
                    if (instantiatedPuzzle == null)
                    {
                        // Instancia el puzzle en la posición donde se detectó el plano
                        instantiatedPuzzle = Instantiate(puzzlePrefab, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}
