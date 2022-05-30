using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Renderer[] materials;
    public Color[] colors;

    public void SetColor(int index)
    {
        materials[index].material.color = colors[index];
    }

}
