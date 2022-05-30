using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalModelManager : MonoBehaviour
{
    public GameObject model;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Set3DModel(GameObject Object)
    {
        model = Object;
    }

    public GameObject Get3DModel()
    {
        return model;
    }
}
