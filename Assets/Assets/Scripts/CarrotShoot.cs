using Unity.VisualScripting;
using UnityEngine;

public class CarrotShoot : MonoBehaviour
{
    private float _carrotSpeed = 5f;

    private int _carrotDamage = 10;

    private Rigidbody2D rigidBody;
    private Transform _playerPos;
    private GameObject _player;


    void OnTriggerEnter2D(Collider2D otherObject)
    {
        PlayerMovement _playerUsed = _player.GetComponent<PlayerMovement>();

        if (otherObject.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            int currentHealth = _playerUsed.GetHealth();
            _playerUsed.SetHealth(currentHealth-_carrotDamage);
        }
    }


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform;

    }

    void FixedUpdate()
    {
        Vector3 direction = _playerPos.position - (Vector3)rigidBody.position;
        direction.Normalize(); //unit vector it

        float angleBullet = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // uses triangles to calculate where the carrot should rotate to face

        rigidBody.linearVelocity = direction * _carrotSpeed; // test logic in game; moves bullet according to where the player is
        rigidBody.rotation = angleBullet;

    }
}