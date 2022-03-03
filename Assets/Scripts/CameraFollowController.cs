using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{

    public Transform ballLocation;
    Vector3 difference;
    // Start is called before the first frame update
    void Start()
    {
        difference = transform.position - ballLocation.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(BallController.isItFall == false)
        {
            transform.position = ballLocation.position + difference;
        }
       
    }
}
