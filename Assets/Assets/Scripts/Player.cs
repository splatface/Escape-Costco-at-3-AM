using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Animator _anim;
    private Vector3 _movementDirection;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
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

        _movementDirection = Vector3.zero;

        if (horizontal != 0)
        {
            _movementDirection = new Vector3(horizontal, 0f, 0f);
        }
        else if (vertical != 0)
        {
            _movementDirection = new Vector3(0f, vertical, 0f);
        }

        transform.position += _movementDirection * moveSpeed * Time.deltaTime;
    }

    public void AnimatePlayer()
    {
        if (_movementDirection == Vector3.down)
        {
            _anim.SetBool("WalkDown", true);
        } else if (_movementDirection == Vector3.up)
        {
            _anim.SetBool("WalkUp", true);
        } else if (_movementDirection == Vector3.left)
        {
            _anim.SetBool("WalkLeft", true);
        } else if (_movementDirection == Vector3.right)
        {
            _anim.SetBool("WalkRight", true);
        } else
        {
            _anim.SetBool("WalkDown", false);
            _anim.SetBool("WalkUp", false);
            _anim.SetBool("WalkLeft", false);
            _anim.SetBool("WalkRight", false);
        }
    }
}