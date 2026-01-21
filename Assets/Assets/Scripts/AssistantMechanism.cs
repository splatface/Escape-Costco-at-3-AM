using System.Collections;
using UnityEngine;

public class AssistantMechanism : MonoBehaviour
{
    public GameObject AssistantAlive;
    public GameObject AssistantDead;
    public GameObject GasCloud;
    public GameObject Gun;
    public GameObject UseGasButton;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssistantAlive.SetActive(true);
        AssistantDead.SetActive(false);
        GasCloud.SetActive(false);
        Gun.SetActive(false);
        UseGasButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        string[] inv = BarInventory.Instance.GetCurrentItems();
        if (inv[0] == "Gas")
        {
            UseGasButton.SetActive(true);
        }
    }
    public void StartGasRelease()
    {
        StartCoroutine(ReleaseGas());
        FullInventory.Instance.RemoveFromInven("Gas");
    }
    IEnumerator ReleaseGas()
    {
        GasCloud.SetActive(true);
        yield return new WaitForSeconds(1f);
        AssistantAlive.SetActive(false);
        AssistantDead.SetActive(true);
        Gun.SetActive(true);
        yield return new WaitForSeconds(1f);
        GasCloud.SetActive(false);
        UseGasButton.SetActive(false);
    }
}
