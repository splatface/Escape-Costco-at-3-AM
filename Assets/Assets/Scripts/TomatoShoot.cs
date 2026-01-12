using UnityEngine;

public class TomatoShoot : MonoBehaviour
{
    private float _tomatoSpeed = 2f;
    private float _disappearTime = 4f;


    private Rigidbody2D rigidBody;

    private Transform _playerPos;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = Player.transform;

        Destroy(gameObject, _disappearTime); // destroys bullet after a certain amount of time

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = _playerPos.position.x - rigidBody.position.x;
        Vector3 direction = new Vector3 (x, 0);
        direction.Normalize(); //unit vector it
        
        rigidBody.linearVelocity = direction * _tomatoSpeed;
    }
}