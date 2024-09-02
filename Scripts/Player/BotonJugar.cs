using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que se quiere cambiar

    private void OnMouseDown()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}