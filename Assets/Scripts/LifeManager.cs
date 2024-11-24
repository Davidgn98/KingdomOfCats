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
                lifes[i].SetActive(true);  // Mostrar el coraz�n si est� dentro del l�mite de vidas
            }
            else
            {
                lifes[i].SetActive(false); // Ocultar el coraz�n si el jugador ha perdido esa vida
            }
        }
    }
}
