using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClick : MonoBehaviour
{
    public Image buttonImage;  // El componente de imagen del botón al que le cambias el color
    public Color colorOnClick; // El color que se aplicará al hacer clic
    public Color defaultColor; // El color por defecto

    public Image otherButtonImage;  // El componente de imagen del otro botón (Next o Previous)

    // Método para cambiar el color cuando se presiona "Previous" o "Next"
    public void ChangeToColorOnClick()
    {
        // Cambia el color del botón que fue presionado
        buttonImage.color = colorOnClick;

        // Cambia el color del otro botón a su color por defecto
        if (otherButtonImage != null)
        {
            otherButtonImage.color = defaultColor;
        }
    }
}
