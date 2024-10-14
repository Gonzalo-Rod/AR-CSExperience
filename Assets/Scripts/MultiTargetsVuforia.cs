using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetsVuforia : MonoBehaviour
{
    [SerializeField] private GameObject starModel; // El modelo inicial que se mostrará
    private int modelsCount;
    private int indexCurrentModel;

    // Start is called before the first frame update
    void Start()
    {
        modelsCount = transform.childCount;
        indexCurrentModel = starModel.transform.GetSiblingIndex();
        
        // Desactivar todos los modelos excepto el actual
        for (int i = 0; i < modelsCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == indexCurrentModel);
        }
    }

    public void ChangeARModel(int index)
    {
        // Desactivar el modelo actual
        transform.GetChild(indexCurrentModel).gameObject.SetActive(false);

        // Calcular el nuevo índice
        int newIndex = indexCurrentModel + index;
        if (newIndex < 0)
        {
            newIndex = modelsCount - 1;
        }
        else if (newIndex > modelsCount - 1)
        {
            newIndex = 0;
        }

        // Activar el nuevo modelo
        GameObject newModel = transform.GetChild(newIndex).gameObject;
        newModel.SetActive(true);
        indexCurrentModel = newModel.transform.GetSiblingIndex();
    }
}
