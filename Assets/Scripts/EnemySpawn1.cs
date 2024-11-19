using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn1 : MonoBehaviour
{
    public GameObject[] ArrayPrefab;
    private int numRandom;
    public int maxRange;
    public float firstCallSpawn;
    public float repeatCallSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", firstCallSpawn, repeatCallSpawn);
    }

    void Update()
    {

    }

    // Update is called once per frame
    private void SpawnEnemy()
    {
        numRandom = Random.Range(0, maxRange);
        Instantiate(ArrayPrefab[numRandom], transform.position, Quaternion.identity);
    }
}
