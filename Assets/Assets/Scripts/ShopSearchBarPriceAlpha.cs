using TMPro;
using UnityEngine;

public class ShopSearchBarPriceAlpha : MonoBehaviour
{
    public TMP_InputField searchInput;
    [SerializeField] private ShopManager _shopManager;

    private void Start()
    {
        searchInput.onValueChanged.AddListener(OnSearchChanged);
    }

    private void OnSearchChanged(string text)
    {
        text = text.Trim();

        if (string.IsNullOrEmpty(text))
        {
            _shopManager.ResetAllVisible();
            return;
        }

        string op = "";
        string value = text;

        if (text.StartsWith(">") || text.StartsWith("<") || text.StartsWith("="))
        {
            op = text[0].ToString();
            value = text.Substring(1);
        }

        _shopManager.FilterPricePlusAlpha(op, value);
    }
}