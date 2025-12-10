using UnityEngine;

public class paralaxx : MonoBehaviour
{

    public Transform cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x / 2, cam.position.y / 2, 0);
    }
}
