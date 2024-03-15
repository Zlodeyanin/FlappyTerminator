using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<PlayerBullet>(out PlayerBullet playerBullet))
        {
            gameObject.SetActive(false);
        }
    }
}