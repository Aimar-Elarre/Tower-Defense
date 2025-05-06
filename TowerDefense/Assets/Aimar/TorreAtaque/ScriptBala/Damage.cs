using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int daño = 10;
    public GameObject numerosDaño;

    private bool _critico = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {

            GameObject texto = Instantiate(numerosDaño,new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z), Quaternion.identity);
            texto.GetComponent<TextMeshPro>().text = daño.ToString();
            float ra = Random.Range(0, 21);
            if (ra >= 16)
            {
                texto.GetComponent<TextMeshPro>().color = Color.yellow;
                daño *= 5;
                texto.GetComponent<TextMeshPro>().text = daño.ToString();
            }
            else
            {
                texto.GetComponent<TextMeshPro>().color = Color.white;
                texto.GetComponent<TextMeshPro>().text = daño.ToString();
            }
            

            EnemiHP enemigo = other.GetComponent<EnemiHP>();
            if (enemigo != null)
            {
                enemigo.HP -= daño;
            }

            Destroy(gameObject); // Destruye la bala tras aplicar daño
        }
    }
}
