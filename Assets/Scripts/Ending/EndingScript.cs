using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public Data data;
    public GameObject endingImage;

    bool isFactoryActive;
    int[] nums;
    int month;

    void Start()
    {
        isFactoryActive = data.getFactoryActivate();
        nums = data.getUserForestUnits();
        month = data.getUserMonth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
