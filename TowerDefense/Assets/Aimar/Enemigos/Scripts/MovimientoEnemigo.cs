using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform[] puntosDeRuta;
    public float velocidad = 3f;
    public float distanciaMinima = 0.1f;

    private int indiceActual = 0;

    void Update()
    {
        if (puntosDeRuta.Length == 0) return;

        Transform destino = puntosDeRuta[indiceActual];
        Vector3 direccion = (destino.position - transform.position).normalized;

        // Mover al enemigo
        transform.position += direccion * velocidad * Time.deltaTime;

        // Rotar hacia la dirección del movimiento si hay movimiento
        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * 5f);
        }

        if (Vector3.Distance(transform.position, destino.position) < distanciaMinima)
        {
            indiceActual = (indiceActual + 1) % puntosDeRuta.Length;
        }
    }

    void OnDrawGizmos()
    {
        if (puntosDeRuta == null || puntosDeRuta.Length < 2) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < puntosDeRuta.Length - 1; i++)
        {
            Gizmos.DrawLine(puntosDeRuta[i].position, puntosDeRuta[i + 1].position);
        }
        Gizmos.DrawLine(puntosDeRuta[puntosDeRuta.Length - 1].position, puntosDeRuta[0].position);
    }
}

