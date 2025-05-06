using UnityEngine;

public class EnemiHP : MonoBehaviour
{
    public int HP = 10;
    public NewSpawnerEnemigos spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            if(spawner != null)
            {
                spawner.NotificarMuerte(gameObject);
            }            
            Destroy(gameObject);
        }
    }
}
