using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryHandler : MonoBehaviour
{
    //these icons are in the islands and must be tagged tro find them]
    [SerializeField] private GameObject Region01Item01;
    [SerializeField] private GameObject Region01Item02;
    [SerializeField] private GameObject Region02Item01;
    [SerializeField] private GameObject Region02Item02;
    
    //event bools
    public bool hasRegion01Item01 { get; set; }
    public bool hasRegion01Item02 { get; set; }
    public bool hasRegion02Item01 { get; set; }
    public bool hasRegion02Item02 { get; set; }

    [Header("Events")]
    public UnityEvent foundRegion01Item01;
    public UnityEvent foundRegion01Item02;
    public UnityEvent foundRegion02Item01;
    public UnityEvent foundRegion02Item02;
    
    public List<GameObject> islandContents = new List<GameObject>();

    public void Start()
    {
        //set all item invisible until we locate them in books
        Region01Item01.SetActive(false);
        Region01Item02.SetActive(false);
        Region02Item01.SetActive(false);
        Region02Item02.SetActive(false);
    }

    void FoundRegion01Item01()
    {
        Region01Item01.SetActive(true);
        //found it so dont need to listen anymore
        //foundApple.RemoveListener(FoundApple);
    }
    
    void FoundRegion01Item02()
    {
        Region01Item02.SetActive(true);
        //foundCorn.RemoveListener(FoundCorn);
    }
    
    void FoundRegion02Item01()
    {
        Region02Item01.SetActive(true);
       // foundLight.RemoveListener(FoundLight);
    }
    
    void FoundRegion02Item02()
    {
        Region02Item02.SetActive(true);
        //foundHammer.RemoveListener(FoundHammer);
    }
}