using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class EnemyMovementPlayer : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private Transform _target;
    private Vector3 _position;

    private void Start()
    {
        _target = GameObject.FindWithTag("Jugador").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        _rb.MovePosition(transform.position + (_speed * Time.fixedDeltaTime * direction));
    }

}
