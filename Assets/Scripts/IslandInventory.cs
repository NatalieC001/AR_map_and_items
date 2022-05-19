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

        //these should all be on the satge.

        //find all items and hide them
        Apple = Instantiate(Resources.Load("prefabs/Apple")) as GameObject;   ///GameObject.FindGameObjectWithTag("Apple");
        Corn =  Instantiate(Resources.Load("prefabs/Corn")) as GameObject;  //GameObject.FindGameObjectWithTag("Corn");
        Light = Instantiate(Resources.Load("prefabs/Light")) as GameObject;
        Hammer = Instantiate(Resources.Load("prefabs/Hammer")) as GameObject;//GameObject.FindGameObjectWithTag("Hammer");
        Chest = Instantiate(Resources.Load("prefabs/Chest")) as GameObject;// ; GameObject.FindGameObjectWithTag("Chest");

        //find all regions and hide them
        Region01 = Instantiate(Resources.Load("prefabs/Region01")) as GameObject;//GameObject.FindGameObjectWithTag("Region01");
        Region02 = Instantiate(Resources.Load("prefabs/Region02")) as GameObject; //GameObject.FindGameObjectWithTag("Region02");
        Region03 =  Instantiate(Resources.Load("prefabs/Region03")) as GameObject; //GameObject.FindGameObjectWithTag("Region03");
        Region04 = Instantiate(Resources.Load("prefabs/Region04")) as GameObject; //GameObject.FindGameObjectWithTag("Region04");

        if (!Apple)
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
        if (!Region01)
        {
            Debug.Log("Region01 tag not found");
        }
        if (!Region02)
        {
            Debug.Log("Region02 tag not found");
        }
        if (!Region03)
        {
            Debug.Log("Region03 tag not found");
        }
        if (!Region04)
        {
            Debug.Log("Region04 tag not found");
        }

        //set all item invisible until we locate them in books
        Apple.SetActive(false);
        Corn.SetActive(false);
        Light.SetActive(false);
        Hammer.SetActive(false);
        Chest.SetActive(false);

        //set all island regions invisible before discovering them
        Region01.SetActive(false);
        Region02.SetActive(false);
        Region03.SetActive(false);
        Region04.SetActive(false);


        foundApple.AddListener(FoundApple);
        foundCorn.AddListener(FoundCorn);
        foundLight.AddListener(FoundLight);
        foundHammer.AddListener(FoundHammer);
        foundChest.AddListener(FoundChest);

        //ad listeners to island parts - find the clue show the region
        foundRegion01.AddListener(FoundRegion01);
        foundRegion02.AddListener(FoundRegion02);
        foundRegion03.AddListener(FoundRegion03);
        foundRegion04.AddListener(FoundRegion04);
    }

    void FoundApple()
    {
        Apple.SetActive(true);

        //found it so dont need to listen anymore
        //foundApple.RemoveListener(FoundApple);
    }
    void FoundCorn()
    {
        Corn.SetActive(true);
        //foundCorn.RemoveListener(FoundCorn);
    }
    void FoundLight()
    {
        Light.SetActive(true);
       // foundLight.RemoveListener(FoundLight);
    }
    void FoundHammer()
    {
        Hammer.SetActive(true);
        //foundHammer.RemoveListener(FoundHammer);
    }
    void FoundChest()
    {
        Chest.SetActive(true);
       // foundChest.RemoveListener(FoundChest);
    }


    void FoundRegion01()
    {
        Debug.Log("found region 1 set active");
        //found the island so it will stay visible - can remove the listener
        Region01.SetActive(true);
       // foundRegion01.RemoveListener(FoundRegion01);
    }
    void FoundRegion02()
    {
        Debug.Log("found region 2 set active");
        Region02.SetActive(true);
       // foundRegion02.RemoveListener(FoundRegion02);
    }
    void FoundRegion03()
    {
        Debug.Log("found region 3 set active");
        Region03.SetActive(true);
       // foundRegion03.RemoveListener(FoundRegion03);
    }
    void FoundRegion04()
    {
        Debug.Log("found region 4 set active");

        Region04.SetActive(true);
       // foundRegion04.RemoveListener(FoundRegion04);
    }


}
