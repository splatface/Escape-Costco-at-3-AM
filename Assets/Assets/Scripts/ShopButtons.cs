using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    public void SortTimePower()
    {
        _shopManager.SortTimePlusPower(); //Sort script objects
        _shopManager.CreateObjectList();  //Sort visual GameObjects
        _shopManager.ChangeObjectPositions(); //Change visual powerup locations according to sort
    }
    public void SortPriceAlpha()
    {
        _shopManager.SortPricePlusAlpha();
        _shopManager.CreateObjectList(); 
        _shopManager.ChangeObjectPositions();
    }

    public void ExitShop()
    {
        SceneManager.LoadScene("MainRoom");
    }
}
