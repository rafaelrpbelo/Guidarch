using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange;
    public LayerMask enemyLayer;
    Collider[] hittableEnemies;


    // Update is called once per frame
    void Update()
    {
        hittableEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
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
        enemy.SendMessage("TakeDamage", 1);
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
