using Unity.VisualScripting;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private void OnTriggerEnter2D(Collider2D collizion)
    {
        if (collizion.TryGetComponent(out Enemy enemy))
        {
            _spawner.ReturnObjectInPool(enemy);
        }
    }
}