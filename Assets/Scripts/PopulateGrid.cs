using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public int quantity;

    private void Start()
    {
        PopulateUI();
    }

    public void PopulateUI()
    {
        GameObject insObj;

        for(int i = 0; i<quantity; i++)
        {
            insObj = (GameObject)Instantiate(prefab, transform);
            insObj.GetComponent<Image>().color = Random.ColorHSV();
        }
    }

}
