using UnityEngine;

// RESOURCE: https://www.youtube.com/watch?v=y2N_J391ptg

public class EnemyHealthBar : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = this.GetComponent<Enemy>();
    }

    private void OnMouseEnter()
    {
        EnemyHealthBarManager._instance.SetAndShowEnemyHealthBar(enemy);
    }

    private void OnMouseExit()
    {
        EnemyHealthBarManager._instance.HideEnemyHeathBar();
    }
}
