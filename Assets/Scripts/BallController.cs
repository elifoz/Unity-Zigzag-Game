using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 aspect;
    public float speed;
    public FloorSpawnerController floorSpawnerScript;
    public static bool isItFall;
    public float addingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        aspect = Vector3.forward;
        isItFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            isItFall = true;
        }
        if (isItFall == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) //sol týklandýysa ve ileri gidiyorsa sola; sola gidiyorsa saða gitsin.
        {
            if(aspect.x == 0)
            {
                aspect = Vector3.left;
            }
            else
            {
                aspect = Vector3.forward;
            }
            speed += addingSpeed * Time.deltaTime;
        }
        
    }

   private void FixedUpdate()
    {
        Vector3 move = aspect * Time.deltaTime * speed;
        transform.position += move;
    }

    private void OnCollisionExit(Collision collision) //temastan çýktýðýn an
    {
        if(collision.gameObject.tag == "Floor")
        {
            ScoreController.score++;
            collision.gameObject.AddComponent<Rigidbody>();
            floorSpawnerScript.createFloor();
            StartCoroutine(DeleteFloor(collision.gameObject));
        }
    }

    IEnumerator DeleteFloor(GameObject DeletingFloor)
    {
        yield return new WaitForSeconds(3f);
        Destroy(DeletingFloor);
    }
}

