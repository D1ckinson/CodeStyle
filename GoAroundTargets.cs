using UnityEngine;

public class GoAroundTargets : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Transform _point;

    private int _currentIndex = 0;
    private Transform[] _targets;

    private void Start()
    {
        _targets = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
            _targets[i] = _point.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform currentTarget = _targets[_currentIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
            TakeNextTarget();
    }

    private void TakeNextTarget()
    {
        if (_currentIndex == _targets.Length)
            _currentIndex = 0;
        else
            _currentIndex++;

        Vector3 targetPosition = _targets[_currentIndex].transform.position;
        transform.forward = targetPosition - transform.position;
    }
}
