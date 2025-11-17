using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    Rigidbody2D rb;
    PlayerController controller;
    Vector2 movement;
    Animator animator;
    [SerializeField] private int facingDirection = 1;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        controller = new PlayerController();
        MovementCalling();
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
        if(movement.x >0 && transform.localScale.x <0 || movement.x <0 && transform.localScale.x >0)
        {
            Flip();
        }
    }


    private void FixedUpdate()
    {
        Vector2 move = (rb.position + movement * speed * Time.deltaTime);
        rb.MovePosition(move);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Horizontal",movement.y);

        animator.SetFloat("Horizontal", movement.sqrMagnitude);

        Attack();
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    }

}
