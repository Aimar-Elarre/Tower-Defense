using UnityEngine;

public class AutodestrucionNumero : MonoBehaviour
{
    public float tiempoDeVida = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
