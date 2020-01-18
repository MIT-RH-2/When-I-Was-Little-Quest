using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMaterialColor : MonoBehaviour
{

    public Material mat;
    public Material brushMat;

    // Start is called before the first frame update
    void Start()
    {
        // pick a random color
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        // apply it on  material
        mat.color = newColor;
        brushMat.color = newColor;
    }
}
