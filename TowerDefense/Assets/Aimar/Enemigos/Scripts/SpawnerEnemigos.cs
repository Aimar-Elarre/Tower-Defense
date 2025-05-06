using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public Transform[] puntosRuta;
    public float intervalo = 3f;

    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= intervalo)
        {
            InstanciarEnemigo();
            tiempo = 0f;
        }
    }

    void InstanciarEnemigo()
    {
        GameObject nuevoEnemigo = Instantiate(prefabEnemigo, transform.position, Quaternion.identity);

        MovimientoEnemigo movimiento = nuevoEnemigo.GetComponent<MovimientoEnemigo>();
        if (movimiento != null)
        {
            movimiento.puntosDeRuta = puntosRuta;
        }
    }
}
