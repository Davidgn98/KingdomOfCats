using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bala")
        {
            Destroy(other.gameObject);
            if(vida == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                vida--;
            }
            
        }
    }
}
