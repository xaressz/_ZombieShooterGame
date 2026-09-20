using UnityEngine;
using System.Collections;

public class GunDamageScript : MonoBehaviour
{
    [Header("Pistol Settings")]
    [SerializeField] private float _damageAmount = 25f;
    [SerializeField] private float _attackRange = 100f;
    [SerializeField] private float _fireRate = 0.15f;

    [Header("Visual Bullet Settings")]
    [SerializeField] private GameObject _bulletPrefab; 
    [SerializeField] private Transform _firePoint;    
    [SerializeField] private float _bulletSpeed = 150f; 

    [Header("References")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private ParticleSystem _muzzleFlash;

    private float _nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_muzzleFlash != null) _muzzleFlash.Play();

        Ray ray = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, _attackRange))
        {
            targetPoint = hit.point;

            if (hit.transform.TryGetComponent<EnemyHealthManager>(out EnemyHealthManager enemy))
            {
                enemy.TakeDamage(_damageAmount);
            }
        }
        else
        {
            targetPoint = ray.GetPoint(_attackRange);
        }

        if (_bulletPrefab != null && _firePoint != null)
        {
            StartCoroutine(MoveBullet(_firePoint.position, targetPoint));
        }
    }

    private IEnumerator MoveBullet(Vector3 startPos, Vector3 targetPos)
    {
        Vector3 direction = (targetPos - startPos).normalized;
        GameObject bullet = Instantiate(_bulletPrefab, startPos, Quaternion.LookRotation(direction));

        float distance = Vector3.Distance(startPos, targetPos);
        float travelled = 0f;

        while (travelled < distance)
        {
            float step = _bulletSpeed * Time.deltaTime;
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, targetPos, step);
            travelled += step;
            yield return null;
        }

        Destroy(bullet);
    }
}
