using UnityEngine;

public class FastGuard : Guard

{
    void Awake()
    {
        _speed = 10f;
        _patrolDistance = 8f;
    }
}

