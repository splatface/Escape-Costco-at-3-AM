using UnityEngine;

public class ItemBaseClass : MonoBehaviour
{

    public string Name = "";
    public string Description = "";
    public string Type = "";

    public SpriteRenderer _renderer;

    private Vector2 _position;

    public Rigidbody2D Item;

    // temporary; may change
    public void MoveItem(float newX, float newY)
    {
        _position = new Vector2 (newX, newY);
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
