using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [Header("Ranged Attack")]
    [SerializeField] public GameObject bullet;
    [SerializeField] public GameObject bulletParent;
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Transform target;
    public float speed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.x > target.position.x && anim.GetBool("isStopped") == false)
        {
            transform.localScale = new Vector3(8, 8, 8);
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("moving", true);
        }
        if (transform.position.x < target.position.x && anim.GetBool("isStopped") == false)
        {
            transform.localScale = new Vector3(-8, 8, 8);
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("moving", true);
        }

        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                anim.SetBool("isStopped", true);
                cooldownTimer = 0;
                anim.SetTrigger("RangedAttack");
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            }
        }
        else
        {
            anim.SetBool("isStopped", false);
        }

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}
