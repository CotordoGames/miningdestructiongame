using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    public float scrollspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, Mathf.Round(player.position.x / 16) * 16, scrollspeed * Time.deltaTime * 55), Mathf.Lerp(transform.position.y, Mathf.Round(player.position.y / 12) * 12, scrollspeed * Time.deltaTime * 55), -10);
    }
}
