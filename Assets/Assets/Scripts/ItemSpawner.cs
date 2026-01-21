using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject MilkPrefab;
    public GameObject BananaPrefab;
    private GameObject ItemSpawned;
    private SpriteRenderer ItemRender;
    public GameObject SpawnItem(string itemTag, Vector3 position)
    {

        if (itemTag == "Milk")
        {
            ItemSpawned = Instantiate(MilkPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "Banana")
        {
            ItemSpawned = Instantiate(BananaPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        ItemRender.sortingLayerName = "ShowInventory";
        ItemRender.sortingOrder = 10;

        return ItemSpawned;
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