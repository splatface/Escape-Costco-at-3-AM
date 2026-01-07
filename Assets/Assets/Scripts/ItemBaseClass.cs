using UnityEngine;

public class ItemBaseClass : MonoBehaviour
{

    private string _name = "";
    private string _description = "";
    private string _type = "";

    public SpriteRenderer _renderer;

    private Vector2 _position;

    public Rigidbody2D Item;

    // temporary; may change
    public void MoveItem(float newX, float newY)
    {
        _position = new Vector2 (newX, newY);
    }

    //all getters for encapsulation
    public string GetDescription()
    {
        return _description;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetItemType()
    {
        return _type;
    }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Item.position = _position;
    }
}
