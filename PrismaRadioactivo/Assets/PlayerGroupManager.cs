using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroupManager : MonoBehaviour
{
    public int AmountOfZombiesChildren;
    public List<GameObject> zombieChildren;

    public void Start()
    {
        for (int i = 0; i < zombieChildren.Count; i++)
        {
            zombieChildren[i].SetActive(false);
        }
    }
    public void AddZombie() 
    {
        AmountOfZombiesChildren++;
        zombieChildren[AmountOfZombiesChildren - 1].SetActive(true);
    }
}
