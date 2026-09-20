using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; // doğacak düşman prefabi
    [SerializeField] private Transform[] _spawnPoints; // doğma noktaları dizisi
    [SerializeField] private float _spawnInterval = 3f; // kaç saniyede bir düşman doğsun
    [SerializeField] private int _maxEnemyCount = 10;   // sahnedeki maks düşman sayısı

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (currentEnemyCount >= _maxEnemyCount) return;
       
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        Transform selectedPoint = _spawnPoints[randomIndex];
  
        Instantiate(_enemyPrefab, selectedPoint.position, selectedPoint.rotation);
        
    }
}