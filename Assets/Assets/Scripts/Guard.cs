using UnityEngine;

public class AutoMoveBackAndForth : MonoBehaviour
{
public float delta = 3.0f;
public float speed = 2.0f;
private Vector3 startPos;
void Start()
{
startPos = transform.position;
}
void Update()
{
float newX = startPos.x + delta * Mathf.Sin(Time.time * speed);
transform.position = new Vector3(newX, startPos.y, startPos.z);
}
}