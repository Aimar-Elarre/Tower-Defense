using UnityEngine;
using UnityEngine.UI;

public class SistemaEconomia : MonoBehaviour
{
    public static SistemaEconomia instancia;

    public int dineroInicial = 100;
    public int dineroActual;
    public Text textoDinero; // UI para mostrar el dinero

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        dineroActual = dineroInicial;
        ActualizarUI();
    }

    public bool PuedeGastar(int cantidad)
    {
        return dineroActual >= cantidad;
    }

    public void GastarDinero(int cantidad)
    {
        dineroActual -= cantidad;
        ActualizarUI();
    }

    public void GanarDinero(int cantidad)
    {
        dineroActual += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoDinero != null)
        {
            textoDinero.text = "$" + dineroActual;
        }
    }
}
