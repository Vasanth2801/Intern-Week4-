using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 4f;
    Rigidbody2D rb;
    bool isChasing;
    Animator animator;
    [SerializeField] int facingDirection = 1;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 2;
    public LayerMask playerLayer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position,transform.position);

        if(distance <= attackRange)
        {
            isChasing = false;
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isRunning", false);
            Attack();
            return;
        }


        
        if(isChasing == true)
        {
            if(player.position.x > transform.position.x && facingDirection == -1 || player.position.x< transform.position.x && facingDirection == 1)
            {
                Flip();
            }
        }

        if(isChasing == true)
        {
               Chase();
        }


        

    }

    void Chase()
    {
        animator.SetBool("isRunning", true);
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");   
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach(Collider2D hitCollider in hitPlayer)
        {
            Vector2 pushDir = (player.position - transform.position);
            player.GetComponent<PlayerMovement>().KnockBack(pushDir);
            Debug.Log("Attacked Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isRunning", false);
            isChasing = false;
            rb.linearVelocity = Vector2.zero;
        }
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
