using UnityEngine;
using System.Collections;

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

        // cool down for 30 seconds
        yield return new WaitForSeconds(enemy.reviveTime);

        enemy.Revive();
    }
}
