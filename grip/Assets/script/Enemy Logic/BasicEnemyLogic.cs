using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyLogic : MonoBehaviour
{
    
    public int maxHealth = 100;
    [HideInInspector] public float health;
    [SerializeField] float spottingDistance;
    [SerializeField] float movementSpeed;
    [SerializeField] float colorDiraction = 0.2f;
    Rigidbody2D rb;
    private float timer;
    private float distance;
    [SerializeField] Color dmgColor; 
    private Renderer objectRenderer;
    private BasicPlayerLogic Player;
    private SpinTool PlayerWeapon;



    //---------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        objectRenderer = GetComponent<Renderer>(); // Get the Renderer component
        Player = GameObject.Find("Player").GetComponent<BasicPlayerLogic>();
        PlayerWeapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<SpinTool>();

        health = maxHealth;
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    //---------------------------------------------------------------------------------------------------------------------------------

    private void Update()
    {
        // the distance between the enemy and the player
        distance = Vector2.Distance(Player.transform.position, transform.position);
    }

    //---------------------------------------------------------------------------------------------------------------------------------

    private void FixedUpdate()
    {
        // if the enemy spots you he'll walk tworeds you
        if (distance < spottingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (Time.fixedTime - timer > 0.02)
            {
                rb.AddForce((transform.position - Player.transform.position) * PlayerWeapon.rotationStrangth *PlayerWeapon.knockback);
                TakeDamage(PlayerWeapon.rotationStrangth*PlayerWeapon.dmgMulitiplyer);
                timer = Time.fixedTime;
            }
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------
    // take dmg function
    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <=0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(ChangeColorCoroutine());
    }

    private System.Collections.IEnumerator ChangeColorCoroutine()
    {
        objectRenderer.material.color = dmgColor;
        yield return new WaitForSeconds(colorDiraction);
        objectRenderer.material.color = Color.white;
    }
}

