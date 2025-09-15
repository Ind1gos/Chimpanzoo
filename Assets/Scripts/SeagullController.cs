using UnityEngine;

public class SeagullController : MonoBehaviour
{
    
    float Seagullspeed = 0.001f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Seagullspeed, 0, 0);
    }
}
