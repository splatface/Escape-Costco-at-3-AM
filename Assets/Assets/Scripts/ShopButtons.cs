using UnityEditor;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    public void SortTimePower()
    {
        ShopManager.SortTimePlusPower(); //Sort
        ShopManager.CreateObjectList(); 
        ShopManager.ChangeObjectPositions(); //Change visual powerup locations according to sort
    }
    public void SortPriceAlpha()
    {
        ShopManager.SortPricePlusAlpha();
        ShopManager.ChangeObjectPositions();
    }
}
