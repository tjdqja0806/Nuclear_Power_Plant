using UnityEngine;

public class PlantLevelXrayMaterial : MonoBehaviour
{
    public Material change;

    private PlantLevelControl script;
    private Material[] origin;
    private GameObject[] xrayObject;
    private MeshRenderer[] image;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();

        xrayObject = GameObject.FindGameObjectsWithTag("Xray");
        origin = new Material[xrayObject.Length];
        image = new MeshRenderer[xrayObject.Length];

        for (int i = 0; i < xrayObject.Length; i++)
        {
            origin[i] = xrayObject[i].GetComponent<MeshRenderer>().material;
            image[i] = xrayObject[i].GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        if (script.isXrayActive)
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = change; }
        }
        else
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = origin[i]; }
        }
    }
}