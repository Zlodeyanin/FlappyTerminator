using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private List<EnemyBullet> _bullets;

    public event Action Defeat;

    private void Start()
    {
        _bullets = new List<EnemyBullet>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<PlayerBullet>(out PlayerBullet playerBullet))
        {
            ReturnBullets();
            gameObject.SetActive(false);
            Defeat?.Invoke();
        }
    }

    private void ReturnBullets()
    {
        _bullets = GetComponentsInChildren<EnemyBullet>().ToList();

        if (_bullets.Count != 0)
        {
            foreach (EnemyBullet bullet in _bullets)
            {
                bullet.transform.position = gameObject.transform.position;
            }
        }
    }
}