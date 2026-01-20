using System.Collections;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Manager"))
        {
            GameObject manager = collision.gameObject;
            ManagerEnemy managerHitbox = manager.GetComponent<ManagerEnemy>();
            managerHitbox.LoseHP(10);
            Destroy(this.gameObject);
        }
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject); 
    }
}
