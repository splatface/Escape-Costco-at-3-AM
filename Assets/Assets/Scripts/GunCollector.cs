using UnityEngine;

public class GunCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frameO
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FullInventory.Instance.PlaceIntoInven("Gun");
            Destroy(this.gameObject);
        }
    }
}
