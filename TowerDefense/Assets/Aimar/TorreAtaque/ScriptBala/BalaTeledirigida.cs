using UnityEngine;

public class BalaTeledirigida : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 5f;
    public float rotacionVelocidad = 5f;

    private Transform objetivo;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        if (objetivo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direccion = (objetivo.position - transform.position).normalized;
        //Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, rotacionVelocidad * Time.deltaTime);
        transform.position += /*transform.forward*/direccion * velocidad * Time.deltaTime;
    }

    public void AsignarObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
    }
}