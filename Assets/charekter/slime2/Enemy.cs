using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvert : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float health = 3;
    public float knockbackForce = 10;
    public float movmentSpeed= 0.3f; 
    public float damage = 1;
    public float xp = 1;
    public float deathAnimationDelay = 1f;
    public bool canTakeDamage = true;
    public bool canAttack = true;
    public bool canMove = true;


    public float Health {
        set {
            health = value;
            if (canTakeDamage) {
            canTakeDamage = false;

            if(health <= 0) {
                Defeated();
            } else {
                animator.SetTrigger("Damage");
                  
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Vector2 difference = (transform.position - player.transform.position).normalized;
                Vector2 force = difference * knockbackForce;
                rb.AddForce(force); 
                
            }
            canTakeDamage = true;
            }
        }
        get {
            return health;
        }
    }

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(canMove) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y - 0.1f);
            transform.position = Vector2.MoveTowards(transform.position, target, movmentSpeed * Time.deltaTime);
        }
        //flip enemy to face player 
        if (transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x) {
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Defeated(){
        canAttack = false;
        canMove = false;
        animator.SetTrigger("Damage");
        animator.SetTrigger("Dead");
        Destroy(gameObject, deathAnimationDelay);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerControler>().Xp += xp;
    }

    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            PlayerControler player = collision.gameObject.GetComponent<PlayerControler>();
            if(player != null && canAttack) {
                player.Health -= damage;
            }
        }
    }
}
