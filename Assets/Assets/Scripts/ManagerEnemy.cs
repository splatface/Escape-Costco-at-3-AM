using UnityEngine;

public class ManagerEnemy : MonoBehaviour
{
    private Vector3 _newPosition;

    public void NormalMovement()
    {
        for (int i=0; i<4; i += 1)
        {
            transform.position += new Vector3(0, (float)0.1); // temporary just to test
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NormalMovement();
    }
}