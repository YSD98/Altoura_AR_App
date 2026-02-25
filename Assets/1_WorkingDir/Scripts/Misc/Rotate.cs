using UnityEngine;
public class Rotate : MonoBehaviour
{
    public float speed = 500f;
    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}