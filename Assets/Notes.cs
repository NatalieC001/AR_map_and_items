using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

//chuck this class out once we have the clues image clues loading one after the other on discovery
public class Notes : MonoBehaviour
{

    public TextMeshProUGUI textLabel;
    public int currLibraryIndex = 0;

    [SerializeField] XRReferenceImageLibrary firstLibrary = null, secondLibrary = null;
    [SerializeField] ARTrackedImageManager manager = null;

    void Update()
    {
        //this would be called once we have the image in view
        if (Input.GetMouseButtonUp(0))
        {
            SwitchImageLibrary();
        }
    }

    public void SwitchImageLibrary()
    {
        currLibraryIndex = currLibraryIndex == 0 ? 1 : 0;
        Debug.Log("setting lib with index " + currLibraryIndex);
        manager.enabled = false;
        var libs = new[] { firstLibrary, secondLibrary };
        manager.referenceLibrary = manager.CreateRuntimeLibrary(libs[currLibraryIndex]);
        manager.enabled = true;


        textLabel.text = libs[currLibraryIndex].ToString();
    }





    //void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    //{
    //    foreach (ARTrackedImage trackedImage in eventArgs.added)
    //    {
    //        switch (trackedImage.referenceImage.name)
    //        {

    //            case "osehero":
    //                m_island01 = Instantiate(foundTrackedImage[0], trackedImage.transform.position, trackedImage.transform.rotation);
    //                m_island01.SetActive(true);
    //                break;

    //            case "Rafflesia":
    //                m_island02 = Instantiate(foundTrackedImage[1], trackedImage.transform.position, trackedImage.transform.rotation);
    //                m_island02.SetActive(true);
    //                break;
    //        }
    //    }

    //    foreach (ARTrackedImage trackedImage in eventArgs.updated)
    //    {
    //        // image is tracking or tracking with limited state, show visuals and update it's position and rotation
    //        if (trackedImage.trackingState == TrackingState.Tracking)
    //        {
    //            switch (trackedImage.referenceImage.name)
    //            {
    //                case "osehero":
    //                    m_island01.SetActive(true);
    //                    m_island01.transform.SetPositionAndRotation(trackedImage.transform.position, trackedImage.transform.rotation);
    //                    break;

    //                case "Rafflesia":
    //                    m_island02.SetActive(true);
    //                    m_island02.transform.SetPositionAndRotation(trackedImage.transform.position, trackedImage.transform.rotation);
    //                    break;
    //            }
    //        }
    //        // image is no longer tracking, disable visuals TrackingState.Limited TrackingState.None
    //        else
    //        {

    //            switch (trackedImage.referenceImage.name)
    //            {
    //                case "osehero":
    //                    m_island01.SetActive(false);
    //                    break;

    //                case "Rafflesia":
    //                    m_island02.SetActive(false);
    //                    break;
    //            }
    //        }

    //    }
    //}
}
