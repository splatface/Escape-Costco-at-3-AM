using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public void SpawnItem(string itemTag, Vector3 position)
    {
        GameObject item = GameObject.FindWithTag(itemTag);
        Instantiate(item, position, transform.rotation);
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