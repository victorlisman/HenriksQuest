using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D enemyBody;
    private Vector2 movement;
    public float attackDamage;
    PlayerMovement Player;
    private float attackSpeed;
    private float canAttack;

    public EnemyScript()
    {
        attackSpeed = 0.5f;
        canAttack = 0.5f;
    }

    void Start()
    {
        enemyBody = this.GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                Player.health = Player.health - attackDamage;
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }

        }

    }

    void MoveCharacter(Vector2 direction)
    {
        enemyBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void Attack()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyBody.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
}