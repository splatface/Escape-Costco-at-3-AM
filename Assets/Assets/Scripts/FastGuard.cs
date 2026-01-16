using UnityEngine;

public class FastGuard : Guard

{
    void Awake()
    {
        _speed = 180f;
        _patrolDistance = 300f;
    }
}

