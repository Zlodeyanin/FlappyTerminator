using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private ScoreCounter _scoreCounter;
    
    private Coroutine _life;

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
            _scoreCounter.Add();
            Debug.Log("Скрипт добавил очко");
        }
    }

    private IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}