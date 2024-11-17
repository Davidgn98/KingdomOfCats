using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform StartPoint;
    public Transform[] Path;
    // Start is called before the first frame update
    void Awake()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
