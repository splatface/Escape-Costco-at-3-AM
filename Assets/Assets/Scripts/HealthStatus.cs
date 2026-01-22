using TMPro;
using UnityEngine;

public class HealthStatus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI _healthStatus;
    [SerializeField] private Player _player;

    void Start()
    {
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        _healthStatus.text = $"Health: {_player.GetHealth()}"; 
    }
}
