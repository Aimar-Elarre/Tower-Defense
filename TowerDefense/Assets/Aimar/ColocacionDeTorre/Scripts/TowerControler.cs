using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject> { }


public class TowerControler : MonoBehaviour
{
    public GameObject torre;
    private GameObject torreEnSelecion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //instanciar la torre si ya hay una torre en torreEnSelecion eliminar de la escena la que esta en torreEnSelecion y poner la nueva selecionada
            if (torreEnSelecion != null)
            {
                Destroy(torreEnSelecion);
            }
            torreEnSelecion = Instantiate(torre,new Vector3(0,-2,0), Quaternion.identity);
           
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (torreEnSelecion != null)
            {
                Destroy(torreEnSelecion);
            }           
        }
    }
    public void TorreSelecionada(Vector3 posicion,bool poner)
    {
        if (torreEnSelecion != null)
        {
            torreEnSelecion.transform.position = posicion + new Vector3(0,1,0);
            if (poner)
            {
                torreEnSelecion.transform.position = posicion + new Vector3(0, 0.75f, 0);
                torreEnSelecion.transform.GetChild(0).GetComponent<CapsuleCollider>().enabled = true;
                torreEnSelecion = null;
            }
        }        
    }
}
