using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rigid;
    [SerializeField] private float xSpeed = 1f;
    [SerializeField] private float ySpeed = 1f;
    
    public LayerMask canCollisionlayer;

    Vector3 lastVelocity;
    float rotateValue;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        rotateValue = Random.Range(-1f, 1f);    
        _rigid.velocity = -new Vector2(xSpeed * rotateValue, ySpeed);
    }

    private void Update()
    {
        lastVelocity = _rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == canCollisionlayer)
        {
            float speed = lastVelocity.magnitude;
            Vector2 dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            _rigid.velocity = dir * Mathf.Max(speed, 0f);
        }
    }
}
