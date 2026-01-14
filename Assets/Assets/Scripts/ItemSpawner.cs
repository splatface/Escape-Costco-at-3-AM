using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject MilkPrefab;
    private GameObject ItemSpawned;
    private SpriteRenderer ItemRender;
    public void SpawnItem(string itemTag, Vector3 position)
    {

        if (itemTag == "Milk")
        {
            ItemSpawned = Instantiate(MilkPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }

        ItemRender.sortingLayerName = "ShowInventory";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}