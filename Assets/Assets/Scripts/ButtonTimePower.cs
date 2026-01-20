using UnityEngine;

public class ButtonTimePower : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    public void OnButtonClicked()
    {
        _shopManager.SortTimePlusPower();
    }
}
