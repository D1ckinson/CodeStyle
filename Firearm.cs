using System.Collections;
using UnityEngine;

public class Firearms : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;

    private void Start() =>
        StartCoroutine(Fire());

    private IEnumerator Fire()
    {
        WaitForSeconds wait = new(_shootDelay);

        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.velocity = _bulletSpeed * direction;
            bullet.transform.forward = direction;

            yield return wait;
        }
    }
}
