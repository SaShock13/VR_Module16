using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private EnemyMove enemyMove;

    private void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
    }

    public void TakeDamage()
    {
        Death();
    }

    private void Death() 
    {
        enemyMove.isAlive = false;
        animator.SetTrigger("Death");
    }
}
