using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private Vector2 _direction;
    private Vector3 _dir;
    private float _angle;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.MovePosition(pos + (_direction * _speed * Time.fixedDeltaTime));
    }

    private void Update()
    {
        _dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
    }
}
