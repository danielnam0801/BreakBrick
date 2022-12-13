using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rigid;
    [SerializeField] private float xSpeed = 1f;
    [SerializeField] private float ySpeed = 1f;
    public LayerMask canCollisionlayer;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.velocity = -new Vector2(xSpeed, ySpeed);   
    }

    private void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == canCollisionlayer)
        {
            Vector2 InDir = _rigid.velocity;
            Vector2 InNormal = collision.contacts[0].normal;
            _rigid.velocity = Vector2.Reflect(InDir, InNormal);
        }
    }
}
