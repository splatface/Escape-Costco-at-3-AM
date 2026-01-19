using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public ItemBase ItemBase;

    public void MoveItem(float newX, float newY)
    {
        transform.position = new Vector3 (newX, newY, 0);
    }

    public void EquipItem(ItemBase item)
    {
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
