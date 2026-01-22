using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float _moveSpeed = 10f;
    private int _health = 100;
    private Animator _anim;
    private Vector3 _movementDirection;
    private ItemBase _weapon;
    //Aggregaton where the Player holds the ItemBaseClass attribute
    [SerializeField] private FullInventory _inventory;

    public void Awake()
    {
        this.SetAnimator(GetComponent<Animator>());
        this._weapon = null;
    }

    public void Update()
    {
        if (FullInventory.Instance.GetOpenState() == false)
        {
            Walk();
        }
        AnimatePlayer();
    }

    public void Walk()
    {
        //Get arrow key input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //Set direction to nothing first
        this.SetMovementDirection(Vector3.zero);

        //Prevent the character from moving diagonally -- restrict to up, down, left, right so that it can be animated
        if (horizontalInput != 0)
        {
            //Identify and save direction so that player can be animated accordingly
            this.SetMovementDirection(new Vector3(horizontalInput, 0f, 0f));
        }
        else if (verticalInput != 0)
        {
            this.SetMovementDirection(new Vector3(0f, verticalInput, 0f));
        }

        //Move player
        transform.position += this.GetMovementDirection() * this.GetMoveSpeed() * Time.deltaTime;
    }

    public void AnimatePlayer()
    {
        Animator anim = GetAnimator();
        Vector3 direction = GetMovementDirection();

        //Use direction to animate player accordingly
        anim.SetBool("WalkDown",  direction == Vector3.down);
        anim.SetBool("WalkUp",    direction == Vector3.up);
        anim.SetBool("WalkLeft",  direction == Vector3.left);
        anim.SetBool("WalkRight", direction == Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Final Door"))
        {
            SceneManager.LoadScene("WinScreen"); //Go to win screen
        } else if (other.CompareTag("Shop"))
        {
            SceneManager.LoadScene("Shop"); //Enter shop
        } else if (other.CompareTag("RoastChicken"))
        {
            Destroy(other.gameObject); //Collect chicken
        }
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public float GetMoveSpeed()
    {
        //If the move speed is somehow set out of range, it should not be used
        if (_moveSpeed <= 0 || _moveSpeed > 18)
        {
            throw new System.Exception("Move speed is out of range.");
        }
        
        return this._moveSpeed;
    }

    public void SetMoveSpeed(float newSpeed)
    {
        //Move speed can only be set between 0 and 18
        if (newSpeed > 0 && newSpeed < 18)
        {
            this._moveSpeed = newSpeed;
        } else
        {
            throw new System.Exception("New speed value is out of range.");
        }
    }

    public Animator GetAnimator()
    {
        //Make sure there is an animator before further using it
        if (_anim == null)
        {
            throw new System.Exception("Animator is null.");
        }

        return _anim;
    }
    public void SetAnimator(Animator newAnim)
    {
        this._anim = newAnim;
    }

    public Vector3 GetMovementDirection()
    {
        return this._movementDirection;
    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        this._movementDirection = newDirection;
    }

    public int GetHealth()
    {
        return this._health;
    }

    public void SetHealth(int newHealth)
    {
        //Make sure health cannot be set over maximum or under minimum
        if (newHealth < 0)
        {
            this._health = 0;
        } else if (newHealth > 100)
        {
            this._health = 100;
        } else
        {
            this._health = newHealth;
        }
    }

    public ItemBase GetWeapon()
    {
        return this._weapon;
    }

    public void EquipWeapon(ItemBase weapon)
    {
        _weapon = weapon;
    }

    public void UnequipWeapon()
    {
        _weapon = null;
    }
}