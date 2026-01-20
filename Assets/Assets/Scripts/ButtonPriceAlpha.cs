using UnityEngine;

public class ButtonPriceAlpha : MonoBehaviour
{    
    [SerializeField] private ShopManager _shopManager;
    public void OnButtonClicked()
    {
        _shopManager.SortTimePlusPower();
    }
}
