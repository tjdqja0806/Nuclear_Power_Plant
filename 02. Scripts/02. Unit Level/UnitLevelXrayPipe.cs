using UnityEngine;

public class UnitLevelXrayPipe : MonoBehaviour
{
    public Material change;

    private UnitLevelControl script;

    private GameObject[] xrayObject;
    private Material[] origin;
    private MeshRenderer[] image;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();

        xrayObject = GameObject.FindGameObjectsWithTag("XrayUnitPipe");
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
        if (script.isXrayActive && script.isTourActive)
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = change; }
        }
        else
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = origin[i]; }
        }
    }
}