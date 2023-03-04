using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{

    public int timeToRespawn = 10;

    private void Update()
    {
        if (this.GetComponent<Enemy>().isDead)
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
        yield return new WaitForSeconds(timeToRespawn);

        this.GetComponent<Enemy>().Revive();

    }
}
