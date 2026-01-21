using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject MilkPrefab;
    public GameObject BananaPrefab;
    public GameObject YellowKeyCardPrefab;
    public GameObject BlueKeyCardPrefab;
    public GameObject GreenKeyCardPrefab;
    public GameObject RedKeyCardPrefab;
    public GameObject BleachPrefab;
    public GameObject VinegarPrefab;
    public GameObject GunPrefab;
    public GameObject GasPrefab;
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
        else if (itemTag == "YellowKeyCard") 
        {
            ItemSpawned = Instantiate(YellowKeyCardPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "GreenKeyCard") 
        {
            ItemSpawned = Instantiate(GreenKeyCardPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "RedKeyCard") 
        {
            ItemSpawned = Instantiate(RedKeyCardPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "BlueKeyCard") 
        {
            ItemSpawned = Instantiate(BlueKeyCardPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "Bleach")
        {
            ItemSpawned = Instantiate(BleachPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "Vinegar")
        {
            ItemSpawned = Instantiate(VinegarPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "Gun")
        {
            ItemSpawned = Instantiate(GunPrefab, position, transform.rotation);
            ItemRender = ItemSpawned.GetComponent<SpriteRenderer>();
        }
        else if (itemTag == "Gas")
        {
            ItemSpawned = Instantiate(GasPrefab, position, transform.rotation);
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