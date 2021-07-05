using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 s_MoveDirection;
    public GameObject[] doors;
    public GameObject[] keys;

    public float walkSpeed;
    public float moveSpeed;
    public float sprintSpeed;
    public float stamina;
    public double StaminaCooldown;
    private double s_RegenStamina;
    public double StaminaRegenSpeed;


    public Rigidbody2D playerBody;
    public float health;

    private double s_FrameCounter;

    public PlayerMovement()
    {
        walkSpeed = 5f;
        moveSpeed = 0f;
        sprintSpeed = 10f;
        stamina = 1000f;
        StaminaCooldown = 4f;
        s_RegenStamina = 0f;
        StaminaRegenSpeed = 0.005f;
        s_FrameCounter = 0f;
        health = 1000f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        s_FrameCounter++;

        ProcessInputs();
        StaminaCap();
        StaminaRegen();
        HealthCap();
        CheckFrame();
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
        playerBody.velocity = new Vector2(s_MoveDirection.x * moveSpeed, s_MoveDirection.y * moveSpeed);

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            moveSpeed = sprintSpeed;
            stamina -= 10;
        }
        else if (!Input.anyKey)
            moveSpeed = 0;
        else
            moveSpeed = walkSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            Destroy(col.gameObject);
            Debug.Log("atins");
        }

    }

    void StaminaCap()
    {
        if (stamina < 0)
            stamina = 0;

        if (stamina > 1000)
            stamina = 1000;
    }

    void HealthCap()
    {
        if (health < 0)
            health = 0;
        
        if (health > 1000)
            health = 1000;
    }

    void CheckFrame()
    {
        if (s_FrameCounter == 100)
            s_FrameCounter = 0;
    }

    void StaminaRegen()
    {
        if (Time.time > s_RegenStamina)
        {
            if (moveSpeed != 10)
            {
                stamina += 1;
                s_FrameCounter = 1;
            }
            
            if (s_FrameCounter % 2 == 0)
                s_RegenStamina = Time.time + StaminaCooldown;
            else
                s_RegenStamina = Time.time + StaminaRegenSpeed;
        }

    }
}
