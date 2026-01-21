using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;
    private float _shootForce = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerAttack()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 attackDirection = (mousePosition - transform.position).normalized;
        GameObject attack = Instantiate(Bullet, transform.position, Quaternion.identity);
        Rigidbody2D attackRb = attack.GetComponent<Rigidbody2D>();
        attackRb.linearVelocity = attackDirection * _shootForce;
    }
    public void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string[] inv = BarInventory.Instance.GetCurrentItems();
            if (inv[0] == "Gun")
            {
                PlayerAttack();
            }
                
        }
    }
}
