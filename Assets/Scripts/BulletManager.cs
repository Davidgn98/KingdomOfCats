using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector2 _lookDirection;
    private float _lookAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle + 90f);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x,transform.position.y), transform.rotation);
        }
    }
}
