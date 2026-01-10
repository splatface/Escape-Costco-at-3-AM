using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerEnemy : MonoBehaviour
{
    public PlayerMovement Player;

    // base variables
    private int _attackValue = 10;
    private int _healthValue = 70;

    //variables for moving
    private bool _runMovementAgain = false;

    //variables for attacking
    public Transform ShootPos;
    public GameObject CarrotBullet;



    private float CalculateDistanceApart(Vector3 playerPos, Vector3 managerPos)
    {

        float x = playerPos.x - managerPos.x;
        float y = playerPos.y - managerPos.y;

        float distance = Mathf.Sqrt((float)(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)));

        return distance;
    }

    //movement the manager makes under normal conditions
    public void NormalMovement()
    {
        Vector3 playerPos = Player.GetCurrentPosition();
        Vector3 managerPos = transform.position;

        float distance = CalculateDistanceApart(playerPos, managerPos);

        if (distance > 2f)
        {
            if (playerPos.x < managerPos.x)
            {
                transform.position -= new Vector3 (0.1f, 0);
            }
            else if (playerPos.x > managerPos.x)
            {
                transform.position += new Vector3 (0.1f, 0);
            }
            if (playerPos.y < managerPos.y)
            {
                transform.position -= new Vector3 (0, 0.1f);
            }
            else if (playerPos.y > managerPos.y)
            {
                transform.position += new Vector3 (0, 0.1f);
            }

            NormalMovement(); //check logic if recursion works, not sure
            
        }
    }

    // manager dodges; either set a time cooldown or some restrictions for activation (e.g. distance apart)
    public void Dodge()
    {
        if (Keyboard.current.spaceKey.isPressed) //may need to change key; if player attacks, will move upwards to dodge
        {
            for (int i=0; i<4; i += 1)
            {
                transform.position = new Vector3 (0, 0.1f);
            }
        }
    }

    public void BasicAttack()
    {
        Instantiate(CarrotBullet, ShootPos.position, ShootPos.rotation);
    }

    public void ChargeULT()
    {
        
    }

    public int GetAttackValue()
    {
        return _attackValue;
    }

    public void LoseHP(int damage)
    {
        _healthValue -= damage;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NormalMovement(); // need to find a condition in update to call it on; check
    }

    // Update is called once per frame
    void Update()
    {
        //when to call movement function
        if (_runMovementAgain == true)
        {
            NormalMovement();
            _runMovementAgain = false;
        }

        Vector3 playerPos = Player.GetCurrentPosition();
        Vector3 managerPos = transform.position;

        float distance = CalculateDistanceApart(playerPos, managerPos);

        if (distance > 3f)
        {
            _runMovementAgain = true;
        }
    
        if (_healthValue < 10)
        {
            ChargeULT();
        }
    }
}