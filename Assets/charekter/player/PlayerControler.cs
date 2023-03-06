using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerControler : MonoBehaviour {
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public float health = 10;
    public float maxHealth = 1;
    public float knockbackForce = 50;
    public float Xp = 0;

    public Image green; 
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public GameObject xpText;
    public GameObject upgradeMenu;
    public GameObject deathScreen;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public bool canMove = false;
    public bool canAttack = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = health;
    }

    private void FixedUpdate() {
        if(movementInput != Vector2.zero && canMove)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
        if (canMove){
            if(movementInput.x > 0) {
                spriteRenderer.flipX = false;  
            } else if(movementInput.x < 0) {
                spriteRenderer.flipX = true;
            }
        }
        xpText.GetComponent<TextMeshProUGUI>().text = "XP: " + Xp;
        green.fillAmount = health / maxHealth;
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        if (canAttack) {
            animator.SetTrigger("Attack");
            SwordAttack();
        }
    }

    public void SwordAttack() {
        LockMovement();

        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                upgradeMenu.GetComponent<UIControler>().canOpenMenu = false;

                animator.SetTrigger("Dead");
                canMove = false;

                GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
                spawner.GetComponent<EnemySpawner>().canSpawn = false;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach(GameObject enemy in enemies) {
                    Destroy(enemy);
                }

                Invoke("StopPlayerAnimation", 1.2f);

                Invoke("ShowDeathScreen", 1.5f);

                
            } else {
                // animator.SetTrigger("Damage");

                GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
                Vector2 difference = (transform.position - enemy.transform.position).normalized;
                Vector2 force = difference * knockbackForce;
                rb.AddForce(force); 
            }
        }
        get {
            return health;
        }
    }

    void StopPlayerAnimation() {
        animator.gameObject.GetComponent<Animator>().enabled = false;
    }

    public void StartPlayerAnimation() {
        animator.gameObject.GetComponent<Animator>().enabled = true;
        animator.SetTrigger("New Trigger");
    }

    void ShowDeathScreen() {
        deathScreen.SetActive(true);
    }
}
