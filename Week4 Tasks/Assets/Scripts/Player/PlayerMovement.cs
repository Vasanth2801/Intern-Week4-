using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    Rigidbody2D rb;
    PlayerController controller;
    Vector2 movement;
    Animator animator;
    [SerializeField] private int facingDirection = 1;
    [SerializeField] Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    public LayerMask enemyLayer;
    private EnemyHealth enemyHealth;
    [SerializeField] private float dashSpeed = 7f;
    [SerializeField] private float dashDuration = 0.05f;
    [SerializeField] private float dashCoolDown = 3f;
    bool isDashing = false;
    bool canDash = true;
    [SerializeField] TrailRenderer trailRenderer;

    void Awake()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        controller = new PlayerController();
        MovementCalling();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    void MovementCalling()
    {
        controller.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controller.Player.Move.canceled += ctx => movement = Vector2.zero;
    }


    private void OnEnable()
    {
        controller.Player.Enable();
    }

    private void OnDisable()
    {
        controller.Player.Disable();
    }

    private void Update()
    {
        if(isDashing)
        {
            return;
        }

        if(movement.x >0 && transform.localScale.x <0 || movement.x <0 && transform.localScale.x >0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        else
        {
            Move();
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Dash());
        }
    }

    private void Move()
    {
        Vector2 move = (rb.position + movement * speed * Time.deltaTime);
        rb.MovePosition(move);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Horizontal", movement.y);

        animator.SetFloat("Horizontal", movement.sqrMagnitude);
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach(Collider2D hit in hitEnemies)
            {
                enemyHealth.TakeDamage(10);
                Debug.Log("Damage done to enemy ");
            }
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator Dash()
    {
        isDashing = true;
        rb.linearVelocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    private void OnDrawGizmos()
    {

        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
