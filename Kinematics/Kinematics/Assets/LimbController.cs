using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    //Should have a transform for an endpoint
    public Transform endpoint;
    //Should have a transform for a beginning point
    public Transform beginPoint;
    //Should have a transform for a beginning latch
    public Transform latch;

    public bool mobile = false;
    
    public float speed = 10;

    public Transform target;

    public float distance;

    public float grabRange;
    public float idealDistance;
    public float grabDistance;
    public Vector3 idealPosition;
    // Start is called before the first frame update
    void Start()
    {
        idealDistance = Vector3.Distance(latch.position, target.position);
        grabDistance = idealDistance + grabRange;
        idealPosition = beginPoint.position;
    }

    // Update is called once per frame
    void Update()
    {

        //My problem with the other methods was that I did'nt realize that for whatever reason
        //Unity wants stuff to be oriented by the z position
        //So having the object jut out of the (0, y, 0) on the object led to funky rotations
        latch.LookAt(endpoint.position);
        distance = Vector3.Distance(latch.position, target.position);
        
        if(mobile)
        {
            if(distance <= grabRange)
            {
                if(distance <= idealDistance)
                {
                    //store these values into a vector //Add this vector to the final 
                    // latch.position += (latch.position - target.position) * Time.deltaTime;
                    idealPosition += (latch.position - target.position) * Time.deltaTime;
                }
                else
                {
                    // latch.position -= (latch.position - target.position) * Time.deltaTime;
                    idealPosition -= (latch.position - target.position) * Time.deltaTime;
                }
                

            }
           
        }//Refactor so that this only applies to the grabbing arm

        //what could be issues with this
        //the objects transforms could be fucking up
        //so for the middle limb it is applying the distance formula and tripping out
        //So I need to refacter this so it still takes into account the target but it is overruled by the bone it is connected to.
        //The bottom limb is rotating super fast because the middle limb is jittering
        //So how do I fix this
        //so all the end points should be mobile
        //right now I'm adjusting the latch positions
        //I should rotate the latch 
        //Move the beginning points maybe?
        //I'm hungry come back to this laterl

        latch.position = idealPosition;


       
        

    }

    private void LateUpdate()
    {
       
    }
}
