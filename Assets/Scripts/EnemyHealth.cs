using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public  float health;
    public float currentHealth;
    private Animator anim;

    private void Start()
    {  
        anim= GetComponent<Animator>();
        currentHealth = health;
    }

    private void Update()   
    {
       
        if (health<currentHealth)
        {
            currentHealth = health;
            anim.SetTrigger("Attacked");
        }

        if(health<=0)
        {
            anim.SetBool("isDead", true);
            Debug.Log("Enemy is dead");
        }

    }

    public void DeleteEnemye()
    {
        Destroy(gameObject);
    }

}
