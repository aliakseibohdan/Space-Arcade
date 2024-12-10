using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuztomizeShipColor : MonoBehaviour
{
    [SerializeField]
    private Material[] shipMaterials;
    [SerializeField]
    private MeshRenderer shipRenderer;
    int index;
    public void ChooseMaterialLeft()
    {
        index--;
        if (index < 0) index = shipMaterials.Length - 1;
        shipRenderer.material = shipMaterials[index];
    }

    public void ChooseMaterialRight()
    {
        index++;
        if (index > shipMaterials.Length - 1) index = 0;
        shipRenderer.material = shipMaterials[index];
    }

    public void SelectMaterial()
    {
        PlayerPrefs.SetInt("shipMaterial", index);
        SceneManager.LoadScene(0);
    }
}
