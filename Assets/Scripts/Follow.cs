using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.position = player.position;
    }
}