using UnityEngine;

public class InvenButtons : MonoBehaviour
{
    public Canvas Renderer;
    public void ButtonClicked(int buttonNum)
    {
        FullInventory.Instance.OnClickItem(buttonNum);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FullInventory.Instance.GetOpenState() == true)
        {
                Renderer.sortingLayerName = "ShowInventory";
        }
        else
        {
            Renderer.sortingLayerName = "HideInventory";
        }
    }
}