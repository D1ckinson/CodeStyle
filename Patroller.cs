using UnityEngine;

public class Patroller : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Transform _patrol;

    private int _currentIndex = 0;
    private Transform[] _patrolPoints;

    private void Start()
    {
        _patrolPoints = new Transform[_patrol.childCount];

        for (int i = 0; i < _patrol.childCount; i++)
            _patrolPoints[i] = _patrol.GetChild(i);
    }

    private void Update()
    {
        Transform currentTarget = _patrolPoints[_currentIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
            SwitchTarget();
    }

    private void SwitchTarget()
    {
        if (_currentIndex == _patrolPoints.Length - 1)
            _currentIndex = 0;
        else
            _currentIndex++;

        Vector3 targetPosition = _patrolPoints[_currentIndex].position;
        transform.forward = targetPosition - transform.position;
    }
}
