using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    private Coroutine _moveCoroutine;
    
    private void OnEnable()
    {
        _moveCoroutine = StartCoroutine(Move());
    }

    private void OnDisable()
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
    }

    public virtual IEnumerator Move()
    {
        while (enabled)
        {
            transform.Translate(Vector3.up * (Speed * Time.deltaTime));
            yield return null;
        }
    }
}