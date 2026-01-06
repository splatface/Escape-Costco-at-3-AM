using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 10f;
    private Animator _anim;
    private Vector3 _movementDirection;

    public void Awake()
    {
        this.SetAnimator(GetComponent<Animator>());
    }

    public void Update()
    {
        Walk();
        AnimatePlayer();
    }

    public void Walk()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        this.SetMovementDirection(Vector3.zero);

        if (horizontal != 0)
        {
            this.SetMovementDirection(new Vector3(horizontal, 0f, 0f));
        }
        else if (vertical != 0)
        {
            this.SetMovementDirection(new Vector3(0f, vertical, 0f));
        }

        transform.position += this.GetMovementDirection() * this.GetMoveSpeed() * Time.deltaTime;
    }

    public void AnimatePlayer()
    {
        Animator anim = GetAnimator();
        Vector3 direction = GetMovementDirection();

        anim.SetBool("WalkDown",  direction == Vector3.down);
        anim.SetBool("WalkUp",    direction == Vector3.up);
        anim.SetBool("WalkLeft",  direction == Vector3.left);
        anim.SetBool("WalkRight", direction == Vector3.right);
    }

    public float GetMoveSpeed()
    {
        if (_moveSpeed <= 0)
        {
            throw new System.Exception("Move speed is negative.");
        }
        
        return this._moveSpeed;
    }

    public void SetMoveSpeed(float newSpeed)
    {
        if (newSpeed > 0 && newSpeed < 10)
        {
            this._moveSpeed = newSpeed;
        } else
        {
            throw new System.Exception("New speed value is out of range.");
        }
    }

    public Animator GetAnimator()
    {
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
}