using UnityEngine;

public class CreateGas : MonoBehaviour
{
    public GameObject Bleach;
    public GameObject Vinegar;
    public GameObject OneSubstance;
    public GameObject TwoSubstances;
    private int _substances = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 bleachPosition = new Vector3(-7f, -2f, 1f);
        Instantiate(Bleach, bleachPosition, transform.rotation);
        Vector3 vinegarPosition = new Vector3(7f, -2f, 1f);
        Instantiate(Vinegar, vinegarPosition, transform.rotation);
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
            this._substances += 1;
        }
        // show two substances 
        this._substances += 1;
    }
}
