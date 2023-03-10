using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemySpawning : MonoBehaviour
{
    private Enemy enemy = null;

    private void Awake()
    {
        enemy = this.GetComponent<Enemy>();
    }

    private void Update()
    {
        if (enemy.isDead && enemy.numberOfLives > 0)
        {
            Revive();
        }
    }

    private void Revive()
    {
        StartCoroutine(ReviveCoolDown());
    }

    IEnumerator ReviveCoolDown()
    {

        // wait until enemy revive time expires, then revive
        yield return new WaitForSeconds(enemy.reviveTime);

        enemy.Revive();
    }
}
