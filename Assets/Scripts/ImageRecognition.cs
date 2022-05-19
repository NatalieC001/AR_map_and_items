using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System.Collections.Generic;

public class ImageRecognition  : MonoBehaviour
{
    //changing Image Reference Library at runtime
    //You deactivate ARTrackedImageManager, set a new library, then enable it again.
    [SerializeField] XRReferenceImageLibrary firstLibrary = null, secondLibrary = null;
    [SerializeField] ARTrackedImageManager manager = null;

    public TextMeshProUGUI textLabel;

   public int currLibraryIndex = 0;

    private GameObject m_island01;
    private GameObject m_island02;
    private GameObject m_island03;
    private GameObject m_island04;

    public List<GameObject> foundTrackedImage = new List<GameObject>();
    //void OnEnable()
    //{
    //    m_ImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    //}

    //void OnDisable()
    //{
    //    m_ImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    //}


    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            switch (trackedImage.referenceImage.name)
            {

                case "osehero":
                    m_island01 = Instantiate(foundTrackedImage[0], trackedImage.transform.position, trackedImage.transform.rotation);
                    m_island01.SetActive(true);
                    break;

                case "Rafflesia":
                    m_island02 = Instantiate(foundTrackedImage[1], trackedImage.transform.position, trackedImage.transform.rotation);
                    m_island02.SetActive(true);
                    break;
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            // image is tracking or tracking with limited state, show visuals and update it's position and rotation
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                switch (trackedImage.referenceImage.name)
                {
                    case "osehero":
                        m_island01.SetActive(true);
                        m_island01.transform.SetPositionAndRotation(trackedImage.transform.position, trackedImage.transform.rotation);
                        break;

                    case "Rafflesia":
                        m_island02.SetActive(true);
                        m_island02.transform.SetPositionAndRotation(trackedImage.transform.position, trackedImage.transform.rotation);
                        break;
                }
            }
            // image is no longer tracking, disable visuals TrackingState.Limited TrackingState.None
            else
            {

                switch (trackedImage.referenceImage.name)
                {
                    case "osehero":
                        m_island01.SetActive(false);
                        break;

                    case "Rafflesia":
                        m_island02.SetActive(false);
                        break;
                }
            }

        }
    }


}