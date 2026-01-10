using Unity.VisualScripting;
using UnityEngine;

public class CarrotShoot : MonoBehaviour
{
    private float _bulletSpeed = 3f;
    private float _disappearTime = 4f;

    private Rigidbody2D rigidBody;
    private Transform playerPos;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = Player.transform;

        Destroy(gameObject, _disappearTime); // destroys bullet after a certain amount of time

    }

    void FixedUpdate()
    {
        Vector3 direction = playerPos.position - (Vector3)rigidBody.position;
        direction.Normalize(); //unit vector it

        float angleBullet = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // uses triangles to calculate where the carrot should rotate to face

        rigidBody.linearVelocity = direction * _bulletSpeed; // test logic in game; moves bullet according to where the player is
        rigidBody.rotation = angleBullet;
    }
}