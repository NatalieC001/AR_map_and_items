using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IslandsHandler : MonoBehaviour
{
    [SerializeField] private GameObject Region01;
    [SerializeField] private GameObject Region02;
    [SerializeField] private GameObject Region03;
    [SerializeField] private GameObject Region04;

    public bool hasFoundIsland01 { get; set; }
    public bool hasFoundIsland02 { get; set; }
    public bool hasFoundIsland03 { get; set; }
    public bool hasFoundIsland04 { get; set; }

    [Header("Events")]

    public List<GameObject> islandContents = new List<GameObject>();

    public void Start()
    {
        //set all island regions invisible before discovering them
        Region01.SetActive(false);
        Region02.SetActive(false);
        Region03.SetActive(false);
        Region04.SetActive(false);
        
    }

    public void FoundRegion01()
    {
        Debug.Log("found region 1 set active");
        //found the island so it will stay visible - can remove the listener
        Region01.SetActive(true);
       // foundRegion01.RemoveListener(FoundRegion01);
    }
    
    public void FoundRegion02()
    {
        Debug.Log("found region 2 set active");
        Region02.SetActive(true);
       // foundRegion02.RemoveListener(FoundRegion02);
    }
    
    public void FoundRegion03()
    {
        Debug.Log("found region 3 set active");
        Region03.SetActive(true);
       // foundRegion03.RemoveListener(FoundRegion03);
    }
    
    public void FoundRegion04()
    {
        Debug.Log("found region 4 set active");
        Region04.SetActive(true);
       // foundRegion04.RemoveListener(FoundRegion04);
    }
}