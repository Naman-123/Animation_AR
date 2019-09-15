using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;//calling AR Core

public class MyHelloAR : MonoBehaviour
{
    public Camera MyCamera;//using the camera of phone
    public GameObject AndyPlanePrefab;//when on plane
    public GameObject AndyPointPrefab;//when on point

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch myTouch;//touch type of input to store the input of touch of user
        if(Input.touchCount < 1 || (myTouch = Input.GetTouch(0)).phase != TouchPhase.Began)
        //executed if touch is found else return to go find touch
        {
            return;
        }

        TrackableHit myHit;//store all the info of hit on screen

        TrackableHitFlags RayCastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;
        //a filter for tracking the farame that are beean selected by the google model

        if(Frame.Raycast(myTouch.position.x, myTouch.position.y, RayCastFilter, out myHit))
        //start the raycast of the touch respective to the x and y axis of the plane, only if hit is there
        {
            // read frame and frame.raycast
            GameObject prefab;//creting a object of a prefab depending upon the hit of respective point or plane

            if (myHit.Trackable is FeaturePoint)
            //if it is a point also called as a feature point
            {
                prefab = AndyPointPrefab;
            }
            else
            //else it is a plane for a prefab
            {
                prefab = AndyPlanePrefab;
            }

            var andyObject = Instantiate(prefab, myHit.Pose.position, myHit.Pose.rotation);
            //to generate the game objet that has been called on the plane or points of the AR

            andyObject.transform.Rotate(0, 180.0f, 0, Space.Self);
            //to stop the rotate of the object with respect to the frame of the camera

            var anchor = myHit.Trackable.CreateAnchor(myHit.Pose);
            // create an anchor to hold the object on its own place in the respect of the plane of the virtual points

            andyObject.transform.parent = anchor.transform;
            //creating the ancor a parent of the andyobject to keep the andyobject in it positon
        }

    }
}
