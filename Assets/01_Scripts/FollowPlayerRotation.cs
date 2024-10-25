using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (player != null)
        {
            // Copia la rotación del pivote
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }  
    }
}
