using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARPlaceTrackedImages : MonoBehaviour
{
    // Cache AR tracked images manager from ARCoreSession
    private ARTrackedImageManager _trackedImagesManager;

    IslandInventory _islandInventory;

    // List of prefabs - these have to have the same names as the 2D images in the reference image library
    public GameObject[] ArPrefabs;

    // Internal storage of created prefabs for easier updating
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    // Reference to logging UI element in the canvas
    public TextMeshProUGUI label;

    void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Good reference: https://forum.unity.com/threads/arfoundation-2-image-tracking-with-many-ref-images-and-many-objects.680518/#post-4668326
        // https://github.com/Unity-Technologies/arfoundation-samples/issues/261#issuecomment-555618182

        // Go through all tracked images that have been added
        // (-> new markers detected)
        foreach (var trackedImage in eventArgs.added)
        {
            // check through all images 
            var imageName = trackedImage.referenceImage.name;
            foreach (var curPrefab in ArPrefabs)
            {
               
                if (string.Compare(curPrefab.name, imageName, StringComparison.Ordinal) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    // Found a corresponding prefab for the reference image, and it has not been instantiated yet
                    // -> new instance, with the ARTrackedImage as parent (so it will automatically get updated
                    // when the marker changes in real-life)
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    // Store a reference to the created prefab
                    _instantiatedPrefabs[imageName] = newPrefab;
                    label.text = "found" + imageName;
                    //label.text = $"{Time.time} -> Instantiated prefab for tracked image (name: {imageName}).\n" +
                    //           $"newPrefab.transform.parent.name: {newPrefab.transform.parent.name}.\n" +
                    //           $"guid: {trackedImage.referenceImage.guid}";
                    // Log.text ="Instantiated!";


                    ////////////////finding our items in books and showing on main map!

                    ////////////////finding our items in books and showing on main map!
                    if (imageName == "ApplePrefab")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundApple.Invoke();

                    }
                    if (imageName == "Corn")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundCorn.Invoke();

                    }
                    if (imageName == "Light")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundLight.Invoke();

                    }
                    if (imageName == "Hammer")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundHammer.Invoke();

                    }
                    if (imageName == "Chest")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundHammer.Invoke();

                    }

                    if (imageName == "Region01")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundRegion01.Invoke();

                    }

                    if (imageName == "Region02")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundRegion02.Invoke();

                    }

                    if (imageName == "Region03")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundRegion03.Invoke();

                    }
                    if (imageName == "Region04")
                    {
                        //you found an image of an apple
                        Debug.Log("You found" + imageName);
                        _islandInventory.foundRegion04.Invoke();

                    }

                    ////////////////finding our items in books and showing on main map!

                }
            }

            label.text = trackedImage.referenceImage.name;
        }

        // Disable instantiated prefabs that are no longer being actively tracked
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name]
                .SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        // Remove is called if the subsystem has given up looking for the trackable again.
        // (If it's invisible, its tracking state would just go to limited initially).
        // Note: ARCore doesn't seem to remove these at all; if it does, it would delete our child GameObject
        // as well.
        foreach (var trackedImage in eventArgs.removed)
        {
            // Destroy the instance in the scene.
            // Note: this code does not delete the ARTrackedImage parent, which was created
            // by AR Foundation, is managed by it and should therefore also be deleted
            // by AR Foundation.
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            // Also remove the instance from our array
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);

            // Alternative: do not destroy the instance, just set it inactive
            //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(false);

            label.text = $"REMOVED (guid: {trackedImage.referenceImage.guid}).";
        }
    }








}
