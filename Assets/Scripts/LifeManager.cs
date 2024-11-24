using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public PlayerDamage player;
    public GameObject[] lifes;
    private int vida;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerDamage>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        vida = player.getLife();
        for (int i = 0; i < lifes.Length; i++)
        {
            if (i < vida)
            {
                lifes[i].SetActive(true);  // Mostrar el corazón si está dentro del límite de vidas
            }
            else
            {
                lifes[i].SetActive(false); // Ocultar el corazón si el jugador ha perdido esa vida
            }
        }
    }
}
