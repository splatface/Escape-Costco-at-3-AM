using UnityEngine;

public class SlowGuard : Guard

{
    void Awake()
    {
        _speed = 5f;
        _patrolDistance = 3f;
    }
}