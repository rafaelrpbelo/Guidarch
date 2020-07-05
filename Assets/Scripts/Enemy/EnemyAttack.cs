using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAttack : MonoBehaviour
{
    public LayerMask attackableLayer;

    private EnemyStats stats;

    Collider[] enemiesInAttackRange;
    float nextAttackTime = 0f;
    public float attackCoolDownBase = 4f;

    void Start() {
        stats = this.GetComponent<EnemyStats>();
    }

    void Update()
    {
        enemiesInAttackRange = Physics.OverlapSphere(transform.position, stats.attackRange, attackableLayer);
        AutoAttackListener();
    }

    void AutoAttackListener()
    {
        if (stats.autoAttack) 
        {
            foreach (Collider enemy in enemiesInAttackRange)
            {
                AttackEnemy(enemy);
            }
        }
    }

    void AttackEnemy(Collider enemy)
    {
        if (Time.time >= nextAttackTime)
        {
            enemy.SendMessage("TakeDamage", stats.attackDamage);
            nextAttackTime = Time.time + attackCoolDownBase / stats.attackSpeed;
        }
    }
}
