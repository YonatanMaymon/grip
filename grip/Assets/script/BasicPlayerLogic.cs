using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerLogic : MonoBehaviour
{
    public int maxHealth = 100;
    [HideInInspector] public int health;
    public HealthBar healthBar;
    [SerializeField] private float speed;
    [SerializeField] private float KnockBack;
    [SerializeField] int DamageFromEnemy;
    Rigidbody2D rb;
    private Vector2 move_diraction;

    //---------------------------------------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        healthBar.MaxHealth(maxHealth);
    }
    //---------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        move_diraction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    //---------------------------------------------------------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        rb.AddForce(move_diraction * speed);
    }
    //---------------------------------------------------------------------------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rb.AddForce((transform.position - collision.transform.position) *1000* KnockBack);
            TakeDamage(DamageFromEnemy);
        }

    }
    //---------------------------------------------------------------------------------------------------------------------------------
    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
