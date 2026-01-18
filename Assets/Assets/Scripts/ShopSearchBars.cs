using TMPro;
using UnityEngine;

public class ShopSearchBars : MonoBehaviour
{
    public TMP_InputField searchInput;

    private void Start()
    {
        searchInput.onValueChanged.AddListener(OnSearchChanged);
    }

    private void OnSearchChanged(string text)
    {
        text = text.Trim();

        if (string.IsNullOrEmpty(text))
        {
            ShopManager.ResetAllVisible();
            return;
        }

        char op = '>';
        int number = 0;

        if (text.StartsWith(">") || text.StartsWith("<") || text.StartsWith("="))
        {
            op = text[0];
            int.TryParse(text.Substring(1), out number);
        }
        else
        {
            int.TryParse(text, out number);
        }

        ShopManager.FilterTimePlusPower(op.ToString(), number);
    }
}
