using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;
    private Vector3 _rotation;
    public float range = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, range);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Time.fixedDeltaTime * Vector3.down);
    }

    public void ResetDefaultValues()
    {
        bulletSpeed = 9;
        range = 1f;
    }
}
