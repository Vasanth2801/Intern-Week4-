using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private int angryDamage = 40;


    [SerializeField] Vector3 attackOffset;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask attackMask;


    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D hit = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(hit != null)
        {
            Debug.Log("Boss Attack Hit: " + hit.name);
        }
    }

    public void AngryAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D hit = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(hit != null)
        {
            Debug.Log("Boss Angry Attack Hit: " + hit.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Gizmos.DrawWireSphere(pos, attackRange);
    }
}