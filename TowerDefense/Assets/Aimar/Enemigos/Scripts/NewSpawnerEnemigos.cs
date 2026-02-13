using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewSpawnerEnemigos : MonoBehaviour
{
    public UnityEvent fin;

    [System.Serializable]
    public class Oleada
    {
        public List<GameObject> enemigos;
    }

    public List<Oleada> oleadas;
    public Transform[] puntosRuta;
    public float intervalo = 3f;

    private float tiempo;
    private int indiceOleadaActual = 0;
    private int indiceEnemigoActual = 0;

    private List<GameObject> enemigosVivos = new List<GameObject>();

    private bool oleadaEnCurso = false;
    private bool esperandoConfirmacion = true; // Para activar con botón incluso desde la primera

    void Update()
    {
        if (indiceOleadaActual >= oleadas.Count)
            return;

        if (oleadaEnCurso)
        {
            tiempo += Time.deltaTime;

            if (tiempo >= intervalo)
            {
                InstanciarEnemigo();
                tiempo = 0f;
            }
        }
        else if (enemigosVivos.Count == 0 && !esperandoConfirmacion)
        {
            esperandoConfirmacion = true;
        }
    }

    void InstanciarEnemigo()
    {
        Oleada oleadaActual = oleadas[indiceOleadaActual];

        if (indiceEnemigoActual < oleadaActual.enemigos.Count)
        {
            GameObject prefab = oleadaActual.enemigos[indiceEnemigoActual];
            GameObject nuevoEnemigo = Instantiate(prefab, transform.position, Quaternion.identity);
            enemigosVivos.Add(nuevoEnemigo);

            MovimientoEnemigo movimiento = nuevoEnemigo.GetComponent<MovimientoEnemigo>();
            if (movimiento != null)
            {
                movimiento.puntosDeRuta = puntosRuta;
            }

            EnemiHP enemigoScript = nuevoEnemigo.GetComponent<EnemiHP>();
            if (enemigoScript != null)
            {
                enemigoScript.spawner = this;
            }

            indiceEnemigoActual++;

            if (indiceEnemigoActual >= oleadaActual.enemigos.Count)
            {
                oleadaEnCurso = false;
            }
        }
    }

    public void NotificarMuerte(GameObject enemigo)
    {
        if (enemigosVivos.Contains(enemigo))
        {
            enemigosVivos.Remove(enemigo);
        }
    }

    // Esta función debe llamarse desde un botón UI para iniciar siguiente oleada
    public void ConfirmarSiguienteOleada()
    {
        if (enemigosVivos.Count == 0 && esperandoConfirmacion)
        {
            indiceOleadaActual++;
            if (indiceOleadaActual < oleadas.Count)
            {
                indiceEnemigoActual = 0;
                oleadaEnCurso = true;
                esperandoConfirmacion = false;
            }
            else
            {
                fin.Invoke(); // Se han completado todas las oleadas
            }
        }
    }
}
