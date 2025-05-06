using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float gravedad = -9.81f;
    public float fuerzaSalto = 3f;

    private CharacterController controller;
    private Vector3 velocidadVertical;
    private bool estaEnSuelo;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        estaEnSuelo = controller.isGrounded;

        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(transform.position.x - Camera.main.transform.position.x,0,transform.position.z - Camera.main.transform.position.z).normalized;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            direccion *= vertical;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            direccion = Vector3.Cross(direccion, new Vector3(0, 1, 0));
            direccion *= horizontal;
        }
        else
        {
            direccion *= 0;
        }
        controller.Move(direccion * velocidad * Time.deltaTime);

        if (estaEnSuelo && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            velocidadVertical.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
        }

        velocidadVertical.y += gravedad * Time.deltaTime;
        controller.Move(velocidadVertical * Time.deltaTime);
    }
}
