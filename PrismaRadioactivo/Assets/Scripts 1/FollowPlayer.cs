using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static FollowPlayer Instance { get; private set; }
    public GameObject player;
    public float amountToIncreaseSizePerZombie;
    public float amountToIncreaseYPerZombie;
    private float startingSize;
    private Camera thisCamera;
    [SerializeField]
    private float xAxis, yAxis, originalyAxis;
    private void Start()
    {
        thisCamera = GetComponent<Camera>();
        startingSize = thisCamera.orthographicSize;
        xAxis = transform.localPosition.x - player.transform.localPosition.x ;
        originalyAxis = transform.localPosition.y - player.transform.localPosition.y; 
        
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xAxis, this.transform.position.y, this.transform.position.z);
    }
     private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void UpdateCameraSize(int newAmountofZombies)
    {
        thisCamera.orthographicSize = startingSize + newAmountofZombies * amountToIncreaseSizePerZombie;
        yAxis += originalyAxis + newAmountofZombies * amountToIncreaseYPerZombie;
    }

}
