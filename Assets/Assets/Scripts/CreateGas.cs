using UnityEngine;
using System.Collections;

public class CreateGas : MonoBehaviour
{
    public GameObject Bleach;
    public GameObject Vinegar;
    public GameObject Bowl;
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
        Bleach.SetActive(true);
        Vinegar.SetActive(true);
        MixButton.SetActive(false);
        Transition1.SetActive(false);
        Transition2.SetActive(false);
        Transition3.SetActive(false);
        Transition4.SetActive(false);
        OneSubstance.SetActive(false);
        TwoSubstances.SetActive(false);

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
            OneSubstance.SetActive(true);
            this._substances += 1;
        }
        else 
        {
            // show two substances 
            TwoSubstances.SetActive(true);
            this._substances += 1;
            MixButton.SetActive(true);
        }
    }
    public void DisappearBleach()
    {
        Bleach.SetActive(false);
    }
    public void DisappearVinegar()
    {
        Vinegar.SetActive(false);
    }
    IEnumerator Transition()
    {
        MixButton.SetActive(false);

        Transition1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transition2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transition3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transition4.SetActive(true);

        Instantiate(ToxicGas, transform.position, transform.rotation);
        Bowl.SetActive(false);
        OneSubstance.SetActive(false);
        TwoSubstances.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        Transition4.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Transition3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Transition2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Transition1.SetActive(false);
    }
    public void StartTransition()
    {
        StartCoroutine(Transition());
    }
}
