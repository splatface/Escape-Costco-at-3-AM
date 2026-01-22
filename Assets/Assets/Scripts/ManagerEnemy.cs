using System.Collections;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerEnemy : MonoBehaviour
{
    public Player Player;

    // base variables
    private int _attackValue = 10;
    private int _healthValue = 70;
    public TMP_Text HealthText;
    public Canvas HealthCanvas;
    public GameObject RedKeyCard;

    //variables for moving
    private bool _runMovementAgain = false;
    public ItemSpawner Spawner;
    public SpriteRenderer Renderer;

    //variables for attacking
    public Transform ShootPos;
    public GameObject CarrotBullet;
    public GameObject TomatoBullet;
    private bool _ultUsed = false;
    private bool _diedAlready = false;



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
        GameObject tomatoWeapon = Instantiate(TomatoBullet, ShootPos.position, ShootPos.rotation);
        tomatoWeapon.transform.localScale += new Vector3 (0.5f, 0.5f);
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
            if (_healthValue > 0)
            {
                BasicAttack();
                yield return new WaitForSeconds(4f);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void StartBasicAttack()
    {
        StartCoroutine(WaitBasicAttack());
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartBasicAttack();
        RedKeyCard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Manager Health: " + _healthValue;

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

        // ultimate attack triggered (when to start it and to keep it going for the scaling afterwards until it hits the player)
        if (_healthValue < 10 && _ultUsed == false || GameObject.Find("Tomato") != null && _ultUsed == true)
        {
            Debug.Log("continuing");
            ChargeULT();
            _ultUsed = true;
        }

        if (_healthValue <= 0 && _diedAlready == false)
        {
            GameObject itemSpawn = GameObject.FindWithTag("ItemSpawner");
            Spawner = itemSpawn.GetComponent<ItemSpawner>();
            _healthValue = 0;
            _diedAlready = true;
            Vector3 position = new Vector3 (0, 0);
            RedKeyCard.SetActive(true);
            Destroy(gameObject);
        }
    }
}