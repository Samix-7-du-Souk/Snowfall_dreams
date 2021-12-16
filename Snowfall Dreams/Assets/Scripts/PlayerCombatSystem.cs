using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   /* public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int selectWeapon = 0;

    private void Start()
    {
        SelectWeapon();
    }
    void Update()
    {
        if (Input.GetButtonDown("SpearAttack"))
        {
            Attack();
        }
    }

    void SelectWeapon()
    {
        int w = 0;
        foreach (Transform weapon in transform)
        {
            if (w == selectWeapon)
            {
                weapon.gameObject.SetActive(true);

            }
        }
    }

    void Attack(int dealDamage)
    {
        if ((Input.GetButtonDown("Attack"))
        {
            if (selectWeapon = 0)
            {
                animtor.SetTrigger("AttackSword");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                dealDamage =
            }
            if (selectWeapon = 1)
            {
                animtor.SetTrigger("AttackArrow");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            }
            if (selectWeapon = 2)
            {
                animtor.SetTrigger("AttackSpear");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            }
            if (selectWeapon = 3)
            {
                animtor.SetTrigger("AttackHammer");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            }

        }


        foreach (Collider2D in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);

        }
    }*/
}

