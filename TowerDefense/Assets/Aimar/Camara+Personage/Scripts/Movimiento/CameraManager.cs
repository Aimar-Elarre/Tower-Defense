using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    public Transform objetivo; // El jugador u objeto a orbitar
    public float distancia = 5f;
    public float sensibilidad = 2f;
    public float zoomSpeed = 2f;
    public float minDistancia = 2f;
    public float maxDistancia = 10f;
    public Vector2 limiteRotacion = new Vector2(-60f, 60f);

    private float rotacionX = 20f;
    private float rotacionY = 0f;
    private bool camaraActiva = false;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotacionX = angles.x;
        rotacionY = angles.y;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            camaraActiva = !camaraActiva;
            Cursor.lockState = camaraActiva ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !camaraActiva;
        }

        if (camaraActiva)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

            rotacionY += mouseX;
            rotacionX -= mouseY;
            rotacionX = Mathf.Clamp(rotacionX, limiteRotacion.x, limiteRotacion.y);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distancia -= scroll * zoomSpeed;
        distancia = Mathf.Clamp(distancia, minDistancia, maxDistancia);
    }

    void LateUpdate()
    {
        if (objetivo != null)
        {
            Quaternion rotacion = Quaternion.Euler(rotacionX, rotacionY, 0);
            Vector3 posicion = rotacion * new Vector3(0.0f, 0.0f, -distancia) + objetivo.position;

            transform.rotation = rotacion;
            transform.position = posicion;
        }
    }
}