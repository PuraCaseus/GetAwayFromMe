using UnityEngine;
using System.Collections;

public class Camera_Follow: MonoBehaviour
{

    public Transform Player;
    public float DampTime = 0.4f;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        cameraPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, DampTime);
    }

}