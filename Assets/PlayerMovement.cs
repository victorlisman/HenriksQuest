using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 s_MoveDirection;
    public GameObject[] doors;
    public float MoveSpeed;
    public Rigidbody2D PlayerBody;

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
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        s_MoveDirection = new Vector2(MoveX, MoveY);
    }

    void Move()
    {
        PlayerBody.velocity = new Vector2(s_MoveDirection.x * MoveSpeed, s_MoveDirection.y * MoveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            Destroy(col.gameObject);
            Debug.Log("atins");
        }

    }
}
