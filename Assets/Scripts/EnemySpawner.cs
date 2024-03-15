using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _count;
    [SerializeField] private ScoreCounter _scoreCounter;

    private ObjectPool<Enemy> _pool;
    private Coroutine _spawnEnemies;

    private void Start()
    {
        _pool = new ObjectPool<Enemy>(_enemy, _count, _container);
        _pool.Created += _scoreCounter.OnEnemyCreate;
        _spawnEnemies = StartCoroutine(GenerateEnemies());
    }

    private void Update()
    {
        if (_pool == null)
        {
            StopCoroutine(_spawnEnemies);
        }
    }

    public void Reset()
    {
        _pool.Reset();
    }

    public void ReturnObjectInPool(Enemy enemy)
    {
        _pool.PutElement(enemy);
    }

    private IEnumerator GenerateEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled) 
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        Enemy enemy = _pool.GetFreeElement();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}