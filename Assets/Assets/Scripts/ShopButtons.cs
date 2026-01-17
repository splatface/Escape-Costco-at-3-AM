using UnityEditor;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    public void SortTimePower()
    {
        ShopManager.SortTimePlusPower();
    }

    public void Purchase()
    {
        string parentTag = transform.parent.tag;
        FullInventory.Instance.PlaceIntoInven(parentTag);
    }
}
