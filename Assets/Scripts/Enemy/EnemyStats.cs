using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public bool autoAttack = false;
    public int attackDamage = 1;
    public float attackSpeed = 1f;
    public float attackRange = 1.2f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            Debug.Log("Enemy is already died!!!");
            return;
        }

        if (currentHealth < 1)
            Debug.Log("Enemy died right now!!!");
    }

    public int AttackDamage() {
        return attackDamage;
    }

    // Debug only
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
