using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 temp_position;
    private string PLAYER_TAG = "Player";
    [SerializeField] private float minX, maxX;
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        temp_position = transform.position;
        temp_position.x = player.position.x;

        if (temp_position.x < minX)
        {
            temp_position.x = minX;
        }
        else if (temp_position.x > maxX)
        {
            temp_position.x = maxX;
        }
        transform.position = temp_position;
    }
}
