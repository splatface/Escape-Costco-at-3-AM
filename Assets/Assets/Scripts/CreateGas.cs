using UnityEngine;
using System.Collections;

public class CreateGas : MonoBehaviour
{
    public GameObject Bleach;
    public GameObject Vinegar;
    public GameObject OneSubstance;
    public GameObject TwoSubstances;
    public GameObject MixButton;

    public GameObject Transition1;
    public GameObject Transition2;
    public GameObject Transition3;
    public GameObject Transition4;

    public GameObject ToxicGas;
    
    private int _substances = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 bleachPosition = new Vector3(-7f, -2f, 1f);
        Instantiate(Bleach, bleachPosition, transform.rotation);
        Vector3 vinegarPosition = new Vector3(7f, -2f, 1f);
        Instantiate(Vinegar, vinegarPosition, transform.rotation);
        MixButton.SetActive(false);
        Transition1.SetActive(false);
        Transition2.SetActive(false);
        Transition3.SetActive(false);
        Transition4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetSubstances()
    {
        return this._substances;
    }

    public void AddSubstance()
    {
        if (this._substances == 0)
        {
            // show one substance 
            Vector3 oneSubstancePosition = new Vector3(-0.2f, -1.2f, 1f);
            Instantiate(OneSubstance, oneSubstancePosition, transform.rotation);
            this._substances += 1;
        }
        else 
        {
            // show two substances 
            Instantiate(TwoSubstances, transform.position, transform.rotation);
            this._substances += 1;
            MixButton.SetActive(true);
        }
    }
    IEnumerator Transition()
    {
        Transition1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transition2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transition3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transition4.SetActive(true);
    }
    public void StartTransition()
    {
        StartCoroutine(Transition());
    }
}
