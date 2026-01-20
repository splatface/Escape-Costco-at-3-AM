using System.Collections;
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
    public GameObject TomatoBullet;
    private bool _ultUsed = false;



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
        Instantiate(TomatoBullet, ShootPos.position, ShootPos.rotation);
    }

    public int GetAttackValue()
    {
        return _attackValue;
    }

    public void LoseHP(int damage)
    {
        _healthValue -= damage;
    }

    // Coroutine function for waiting
    IEnumerator WaitBasicAttack()
    {
        while (true)
        {
            BasicAttack();
            yield return new WaitForSeconds(4f);
        }
    }

    public void StartBasicAttack()
    {
        StartCoroutine(WaitBasicAttack());
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NormalMovement(); // need to find a condition in update to call it on; check
        StartBasicAttack();
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

        if (distance > 7f)
        {
            _runMovementAgain = true;
        }

        // ultimate attack triggered    
        if (_healthValue < 10 && _ultUsed == false)
        {
            ChargeULT();
            _ultUsed = true;
        }
    }
}