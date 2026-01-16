using UnityEngine;

public abstract class Guard : MonoBehaviour
{
    // encapsulated variables
    protected float _speed;
    protected float _patrolDistance;

    private Vector3 _startPosition;
    private int _direction = 1;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        MoveBackAndForth();
    }

    private void MoveBackAndForth()
    {
        transform.position += new Vector3(_direction * _speed * Time.deltaTime, 0f, 0f);

        if (Vector3.Distance(transform.position, _startPosition) >= _patrolDistance)
        {
            _direction *= -1;
        }
    }
}
