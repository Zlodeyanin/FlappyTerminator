using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private float _delay = 10f;

    private ObjectPool<EnemyBullet> _pool;
    private Coroutine _shoot;
    private List<EnemyBullet> _enemyBullets;

    private void Start()
    {
        _pool = new ObjectPool<EnemyBullet>(_enemyBullet, 1, gameObject.transform);
        _enemyBullets = new List<EnemyBullet>();
        //_shoot = StartCoroutine(Shoot());
    }

    private void OnEnable()
    {
        _shoot = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        if (_shoot != null)
        {
            StopCoroutine(_shoot);
        }
        
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        
        while (gameObject.activeInHierarchy == true)
        {
            EnemyBullet activeBullet =_pool?.GetFreeElement();
            
            if (activeBullet != null)
            {
                activeBullet.gameObject.SetActive(true);
                activeBullet.transform.position = gameObject.transform.position;
                _enemyBullets.Add(activeBullet);
            }
            
            yield return delay;
        }
    }

    private void ReturnBulletEnemy()
    {
        EnemyBullet bullet = _enemyBullets.FirstOrDefault();
        bullet.transform.position = gameObject.transform.position;
        _pool.PutElement(bullet);
    }
}