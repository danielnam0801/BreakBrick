using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMoving : MonoBehaviour
{
    [SerializeField] float speed = 3;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed ,0);
    }
}
