using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.Path[pathIndex];
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.Path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.Path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        _rb.MovePosition(transform.position + (_speed * Time.fixedDeltaTime * direction));
    }

}
