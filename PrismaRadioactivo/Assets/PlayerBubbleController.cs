using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubbleController : MonoBehaviour
{
    public GameObject BubblePrefab;
    public float launchVelocity;

    public void LaunchBubble() 
    {
        GameObject bubble = Instantiate(BubblePrefab, transform.position, transform.rotation);
        bubble.GetComponent<Rigidbody>().AddForce(new Vector3(launchVelocity, 0, 0));
        
    }
}
