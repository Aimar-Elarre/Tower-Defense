using System.Collections.Generic;
using UnityEngine;

public class ZonaDisparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 1f;

    private List<Transform> enemigosEnRango = new List<Transform>();
    private float temporizador = 1;

    void Update()
    {
        temporizador += Time.deltaTime;
        if (enemigosEnRango.Count == 0)
        {
            return;
        }
        if (enemigosEnRango[0] == null)
        {
            enemigosEnRango.RemoveAt(0);
        }

        if (temporizador >= tiempoEntreDisparos)
        {
            Disparar();
            temporizador = 0f;
        }
    }

    private void Disparar()
    {
        if (enemigosEnRango.Count == 0)
        {
            return;
        }
        Transform objetivo = enemigosEnRango[0];
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        BalaTeledirigida balaScript = bala.GetComponent<BalaTeledirigida>();

        if (balaScript != null)
        {
            balaScript.AsignarObjetivo(objetivo);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemigosEnRango.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemigosEnRango.Remove(other.transform);
        }
    }
}