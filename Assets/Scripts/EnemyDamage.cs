using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int vida;
    [SerializeField] private int exp;
    private PlayerEXP playerEXP;
    // Start is called before the first frame update
    void Start()
    {
        playerEXP = GameObject.FindWithTag("Jugador").GetComponent<PlayerEXP>();
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
                playerEXP.AddEXP(exp);
                Destroy(gameObject);
            }
            else
            {
                vida--;
            }
            
        }
    }
}
