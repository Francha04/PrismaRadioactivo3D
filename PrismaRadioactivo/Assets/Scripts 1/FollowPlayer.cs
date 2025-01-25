using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    private float xAxis, yAxis, zAxis;
    private void Start()
    {
        xAxis = transform.localPosition.x - player.transform.localPosition.x ;
        yAxis = transform.localPosition.y - player.transform.localPosition.y; 
        zAxis = transform.localPosition.z - player.transform.localPosition.z ;
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xAxis, this.transform.position.y, this.transform.position.z);
    }
}
