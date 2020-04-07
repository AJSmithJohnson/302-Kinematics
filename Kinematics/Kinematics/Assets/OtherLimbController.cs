using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherLimbController : MonoBehaviour
{
    public Transform bottomPoint;

    public Transform topPoint;

    public Transform target;

    private Vector3 newTarget;

    public bool isTargetGrabber;
    public bool isLimb = false;

    public Vector3 movementVector;
    public float jointDistance;
    public float flexibility;
    // Start is called before the first frame update
    void Start()
    {

       // newTarget = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(topPoint);
       // movementVector = bottomPoint.position;
        //jointDistance = Vector3.Distance(transform.position, bottomPoint.position);

        //If we want to grab the target
       // print((transform.position - target.position).normalized);
        //Get the distance between the two objects and always try to maintain that
        if(isTargetGrabber)
        {
            //So take the objects position that you want to modify and normalize it to get a vector between 0 and 1
            // multiply by joint distance to get how long you want the vector to be
            //add target position to get the vector pointing the right way
            //without the target position added back in then it points away
            topPoint.position = (transform.position - target.position).normalized * jointDistance + target.position;
            
            if (isLimb)
            {
               // topPoint.position =
            }

        }
        transform.position = (transform.position - topPoint.position).normalized * jointDistance + topPoint.position;
        

        
        
    }
}
