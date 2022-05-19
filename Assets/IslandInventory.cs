using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IslandInventory : MonoBehaviour
{

    //these icons are in the islands and must be tagged tro find them
    private GameObject Apple;
    private GameObject Corn;
    private GameObject Light;
    private GameObject Hammer;
    private GameObject Chest;

    private GameObject Region01;
    private GameObject Region02;
    private GameObject Region03;
    private GameObject Region04;

    //event bools
    public bool hasApple { get; set; }
    public bool hasCorn { get; set; }
    public bool hasLight { get; set; }
    public bool hasHammer { get; set; }
    public bool hasChest { get; set; }
    public bool hasFoundIsland01 { get; set; }
    public bool hasFoundIsland02 { get; set; }
    public bool hasFoundIsland03 { get; set; }
    public bool hasFoundIsland04 { get; set; }

    [Header("Events")]
    public UnityEvent foundApple;
    public UnityEvent foundCorn;
    public UnityEvent foundLight;
    public UnityEvent foundHammer;
    public UnityEvent foundChest;
    public UnityEvent foundRegion01;
    public UnityEvent foundRegion02;
    public UnityEvent foundRegion03;
    public UnityEvent foundRegion04;


    public List<GameObject> islandContents = new List<GameObject>();

    public void Start()
    {
        Apple = GameObject.FindGameObjectWithTag("Apple");
        Corn = GameObject.FindGameObjectWithTag("Corn");
        Light = GameObject.FindGameObjectWithTag("Light");
        Hammer = GameObject.FindGameObjectWithTag("Hammer");
        Chest = GameObject.FindGameObjectWithTag("Chest");

        if (!Apple )
        {
            Debug.Log("Apple tag not found"); 
        }
        if (!Corn)
        {
            Debug.Log("Corn tag not found");
        }
        if (!Light)
        {
            Debug.Log("Light tag not found");
        }
        if (!Hammer)
        {
            Debug.Log("Hammer tag not found");
        }
        if (!Chest)
        {
            Debug.Log("Chest tag not found");
        }
        if (!hasFoundIsland01)
        {
            Debug.Log("hasFoundIsland01 tag not found");
        }
        if (!hasFoundIsland02)
        {
            Debug.Log("hasFoundIsland02 tag not found");
        }
        if (!hasFoundIsland03)
        {
            Debug.Log("hasFoundIsland03 tag not found");
        }
        if (!hasFoundIsland04)
        {
            Debug.Log("hasFoundIsland04 tag not found");
        }

        //set all invisible until we locate them in books
        Apple.SetActive(false);
        Corn.SetActive(false);
        Light.SetActive(false);
        Hammer.SetActive(false);
        Chest.SetActive(false);

        foundApple.AddListener(FoundApple);
        foundCorn.AddListener(FoundCorn);
        foundLight.AddListener(FoundLight);
        foundHammer.AddListener(FoundHammer);
        foundChest.AddListener(FoundChest);

        foundRegion01.AddListener(FoundRegion01);
        foundRegion02.AddListener(FoundRegion02);
        foundRegion03.AddListener(FoundRegion03);
        foundRegion04.AddListener(FoundRegion04);
    }

    void FoundApple()
    {
        Apple.SetActive(true);

        //found it so dont need to listen anymore
        foundApple.RemoveListener(FoundApple);
    }
    void FoundCorn()
    {
        Corn.SetActive(true);
        foundCorn.RemoveListener(FoundCorn);
    }
    void FoundLight()
    {
        Light.SetActive(true);
        foundLight.RemoveListener(FoundLight);
    }
    void FoundHammer()
    {
        Hammer.SetActive(true);
        foundHammer.RemoveListener(FoundHammer);
    }
    void FoundChest()
    {
        Chest.SetActive(true);
        foundChest.RemoveListener(FoundChest);
    }

 
    void FoundRegion01()
    {
        //found the island so it will stay visible - can remove the listener
        foundRegion01.RemoveListener(FoundRegion01);
    }
    void FoundRegion02()
    {
        foundRegion02.RemoveListener(FoundRegion02);
    }
    void FoundRegion03()
    {
        foundRegion03.RemoveListener(FoundRegion03);
    }
    void FoundRegion04()
    {
        foundRegion04.RemoveListener(FoundRegion04);
    }


}
