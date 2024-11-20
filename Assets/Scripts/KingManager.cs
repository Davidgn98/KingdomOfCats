using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    [SerializeField] private int vida;
    public GameObject finJuego;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            if (vida == 0)
            {
                Destroy(gameObject);
                finJuego.SetActive(true);

            }
            else
            {
                vida--;
            }

        }
    }
}
