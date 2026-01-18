using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGasScene : MonoBehaviour
{
    public GameObject GasSign;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GasSign.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GasSign.SetActive(false);
            SceneManager.LoadScene("GasCreation");
        }
        
    }
}
