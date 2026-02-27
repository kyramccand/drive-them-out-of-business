using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform store;

    void Start() {
        transform.position = new Vector3(store.position.x, store.position.y, -1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -1);
        }
    }
}
