using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10f;

    void Update()
    {
        Walk();
    }

    public void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 xMovement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += xMovement;

        Vector3 movement = new Vector3(0.0f, verticalInput, 0.0f); 
        transform.position += movement * moveSpeed * Time.deltaTime;    
    }
    
}
