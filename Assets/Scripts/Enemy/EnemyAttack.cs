using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyAttack : MonoBehaviour
{
    public LayerMask attackableLayer;

    private EnemyStats stats;

    Collider[] enemiesInAttackRange;

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
                enemy.SendMessage("TakeDamage", stats.attackDamage);
            }
        }
    }
}
