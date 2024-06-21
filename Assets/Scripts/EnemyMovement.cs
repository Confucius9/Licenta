using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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
            transform.localScale = new Vector3(-8, 8, 8);
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("moving", true);
        }
        if (transform.position.x < target.position.x && anim.GetBool("isStopped") == false)
        {
            transform.localScale = new Vector3(8, 8, 8);
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("moving", true);
        }
    }

}
