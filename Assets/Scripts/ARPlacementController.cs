using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlacementController : MonoBehaviour
{
    public ARSessionOrigin sessionOrigin;

    public GameObject ARObject;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    private ARPlaneManager planeManager;
    public GlobalModelManager modelManager;

    void Start()
    {

        modelManager = GameObject.FindObjectOfType<GlobalModelManager>(); 

        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        ARObject = modelManager.Get3DModel();
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }


        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = sessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;

            // Calibrate Camera Orientation
            var cameraForward = sessionOrigin.camera.transform.forward;
            var cameraOrientation = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            PlacementPose.rotation = Quaternion.LookRotation(cameraOrientation);
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(ARObject, PlacementPose.position, PlacementPose.rotation);
        //placementIndicator.SetActive(false);

        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

    }

    public void DestroyGlobalModelManager()
    {
        GameObject globalModelManager = GameObject.Find("GlobalModelContainer");
        Destroy(globalModelManager);
    }
}
