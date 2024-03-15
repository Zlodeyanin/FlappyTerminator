using System;
using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2f;

    private Coroutine _life;

    public event Action EnemyDefeat;
    
    private void OnEnable()
    {
        _life = StartCoroutine(DeactivateObject());
    }

    private void OnDisable()
    {
        StopCoroutine(_life);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player) == false)
        {
            gameObject.SetActive(false);
        }

        if (collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            EnemyDefeat?.Invoke();
        }
    }

    private IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}