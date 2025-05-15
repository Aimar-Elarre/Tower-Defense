using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewSpawnerEnemigos : MonoBehaviour
{
    public UnityEvent fin;
    [System.Serializable]
    public class Oleada
    {
        public List<GameObject> enemigos; // Enemigos de esta oleada
    }

    public List<Oleada> oleadas;
    public Transform[] puntosRuta;
    public float intervalo = 3f;

    private float tiempo;
    private int indiceOleadaActual = 0;
    private int indiceEnemigoActual = 0;

    private List<GameObject> enemigosVivos = new List<GameObject>();

    private bool oleadaEnCurso = false;

    void Update()
    {
        // Si no quedan oleadas, termina
        if (indiceOleadaActual >= oleadas.Count)
            return;

        // Si estamos en medio de una oleada, instanciar enemigos en intervalo
        if (oleadaEnCurso)
        {
            tiempo += Time.deltaTime;

            if (tiempo >= intervalo)
            {
                InstanciarEnemigo();
                tiempo = 0f;
            }
        }
        else
        {
            // Si no quedan enemigos vivos, pasar a la siguiente oleada
            if (enemigosVivos.Count == 0)
            {
                indiceOleadaActual++;
                if (indiceOleadaActual < oleadas.Count)
                {
                    // Empezar nueva oleada
                    indiceEnemigoActual = 0;
                    oleadaEnCurso = true;
                }
                if (indiceOleadaActual == oleadas.Count)
                {
                    fin.Invoke();
                }
            }
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

            // Si ya instanciamos todos los enemigos de la oleada, marcamos que la oleada terminó de spawn
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
}