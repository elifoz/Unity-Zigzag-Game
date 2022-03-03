using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawnerController : MonoBehaviour
{
    public GameObject lastFloor;


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            createFloor();
          
        }
    }

   public void createFloor()
    {
        Vector3 aspect;
        if (Random.Range(0, 2) == 0) //0 yada 1 deðerleri random gelecek.
        {
            aspect = Vector3.left;
        }
        else
        {
            aspect = Vector3.forward;
        }
        lastFloor = Instantiate(lastFloor, lastFloor.transform.position + aspect, lastFloor.transform.rotation);
    }
}
