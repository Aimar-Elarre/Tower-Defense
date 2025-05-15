using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject panelSeleccionNiveles;

    void Start()
    {
        panelSeleccionNiveles.SetActive(false); // Oculta panel al inicio
    }

    // Llamado al presionar "Jugar"
    public void MostrarSeleccionNiveles()
    {
        panelSeleccionNiveles.SetActive(true);
    }
    public void DejarMostrarSeleccionNiveles()
    {
        panelSeleccionNiveles.SetActive(false);
    }

    // Llamado al presionar nivel 0
    public void CargarNivel0()
    {
        SceneManager.LoadScene(0);
    }
    // Llamado al presionar nivel 1
    public void CargarNivel1()
    {
        SceneManager.LoadScene(1);
    }

    // Llamado al presionar nivel 2
    public void CargarNivel2()
    {
        SceneManager.LoadScene(2);
    }

    // Llamado al presionar salir
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Salir (solo funciona en build, no en editor)");
    }
}
