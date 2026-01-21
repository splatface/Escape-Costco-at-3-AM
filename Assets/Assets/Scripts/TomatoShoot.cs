using UnityEngine;

public class TomatoShoot : MonoBehaviour
{
    private float _tomatoSpeed = 5f;
    private int  _tomatoDamage = 30;


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
            _playerUsed.SetHealth(currentHealth-_tomatoDamage);

        }
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform;
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