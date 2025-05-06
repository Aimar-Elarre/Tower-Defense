using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ColocarEvent : UnityEvent<Vector3,bool> { }


public class ColocarTorre : MonoBehaviour
{
    public ColocarEvent colocarTorre;
    public bool sePuedePoner = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (sePuedePoner)
        {
            //Debug.Log("raton sobre " + this.gameObject.name);
            colocarTorre.Invoke(transform.position, false);
            if (Input.GetMouseButtonDown(0))
            {
                colocarTorre.Invoke(transform.position, true);
            }
        }
      
        
    }
   
    
}
