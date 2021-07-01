using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 m_MoveDirection;
    public float fMoveSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float fMoveX = Input.GetAxisRaw("Horizontal");
        float fMoveY = Input.GetAxisRaw("Vertical");

        m_MoveDirection = new Vector2(fMoveX, fMoveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(m_MoveDirection.x * fMoveSpeed, m_MoveDirection.y * fMoveSpeed);
    }
}
