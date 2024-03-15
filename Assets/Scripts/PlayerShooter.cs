using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerBullet _playerBullet;
    
    private ObjectPool<PlayerBullet> _pool;
    private Coroutine _shooting;

    private void Start()
    {
        _pool = new ObjectPool<PlayerBullet>(_playerBullet, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBullet bullet = _pool.GetFreeElement();
            bullet.transform.position = gameObject.transform.position;
            bullet.gameObject.SetActive(true);
        }
    }

}