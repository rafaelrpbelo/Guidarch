using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerAttack : MonoBehaviour
{
    public float attackRange;
    public LayerMask enemyLayer;

    PlayerStats stats;

    Collider[] hittableEnemies;

    float nextAttackTime = 0f;
    public float attackCoolDownBase = 4f;

    void Update()
    {
        hittableEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        stats = this.GetComponent<PlayerStats>();
    }

    public bool CanAttack(GameObject enemy)
    {
        if (hittableEnemies.Length < 1 ||  !enemy.CompareTag("Enemy"))
            return false;

        foreach(Collider hittableEnemy in hittableEnemies)
        {
            if (hittableEnemy.gameObject == enemy) {
                return true;
            }
        }

        return false;
    }

    public void Attack(GameObject enemy) {
        if (Time.time >= nextAttackTime)
        {
            enemy.SendMessage("TakeDamage", stats.attackDamage);
            nextAttackTime = Time.time + attackCoolDownBase / stats.attackSpeed;
        }
    }

    // Debug only
    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
