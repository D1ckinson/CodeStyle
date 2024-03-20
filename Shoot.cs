using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shotDelay;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _target;

    private void Start() =>
        StartCoroutine(Fire());

    private IEnumerator Fire()
    {
        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.forward = direction;
            bullet.GetComponent<Rigidbody>().velocity = _bulletSpeed * direction;

            yield return new WaitForSeconds(_shotDelay);
        }
    }
}
