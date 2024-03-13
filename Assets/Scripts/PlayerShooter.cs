using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerBullet _playerBullet;

    private ScoreCounter _scoreCounter;
    private ObjectPool<PlayerBullet> _pool;
    private Coroutine _shooting;

    private void Start()
    {
        _pool = new ObjectPool<PlayerBullet>(_playerBullet, 0);
        _scoreCounter = GetComponent<ScoreCounter>();
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
    
    private void OnEnable()
    {
        _playerBullet.EnemyDefeat += AddScore;
    }

    private void OnDisable()
    {
        _playerBullet.EnemyDefeat -= AddScore;
    }

    private void AddScore()
    {
        _scoreCounter.Add();
        Debug.Log("PlayerShooter засчитал попадание");
    }
}