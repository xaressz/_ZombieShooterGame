using UnityEngine;

public static class GunDamageCalculator
{
    public static void ApplyDamageFromCollision(Collision collision, float damageAmount)
    {
        if (collision.transform.TryGetComponent<EnemyHealthManager>(out EnemyHealthManager targetEnemy))
        {
            targetEnemy.TakeDamage(damageAmount);
        }
    }
}