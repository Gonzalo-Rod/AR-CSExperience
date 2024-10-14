using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HomeManager : MonoBehaviour
{
    public void GoToVuforiaScreen()
    {
        SceneManager.LoadScene("VuforiaScreen");
    }
}
