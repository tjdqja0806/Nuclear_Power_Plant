using UnityEngine;

public class PrimaryXray : MonoBehaviour
{
    public Material facilities;
    public Material waterBlue;
    public Material waterRed;

    private PrimaryControl script;

    private GameObject[] xrayObject;
    private Material[] origin;
    private MeshRenderer[] image;

    private GameObject[] xrayWaterBlue;
    private Material[] originWaterBlue;
    private MeshRenderer[] imageWaterBlue;

    private GameObject[] xrayWaterRed;
    private Material[] originWaterRed;
    private MeshRenderer[] imageWaterRed;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<PrimaryControl>();

        xrayObject = GameObject.FindGameObjectsWithTag("Xray");
        origin = new Material[xrayObject.Length];
        image = new MeshRenderer[xrayObject.Length];
        for (int i = 0; i < xrayObject.Length; i++)
        {
            origin[i] = xrayObject[i].GetComponent<MeshRenderer>().material;
            image[i] = xrayObject[i].GetComponent<MeshRenderer>();
        }

        xrayWaterBlue = GameObject.FindGameObjectsWithTag("XrayWaterBlue");
        originWaterBlue = new Material[xrayWaterBlue.Length];
        imageWaterBlue = new MeshRenderer[xrayWaterBlue.Length];
        for (int i = 0; i < xrayWaterBlue.Length; i++)
        {
            originWaterBlue[i] = xrayWaterBlue[i].GetComponent<MeshRenderer>().material;
            imageWaterBlue[i] = xrayWaterBlue[i].GetComponent<MeshRenderer>();
        }

        xrayWaterRed = GameObject.FindGameObjectsWithTag("XrayWaterRed");
        originWaterRed = new Material[xrayWaterRed.Length];
        imageWaterRed = new MeshRenderer[xrayWaterRed.Length];
        for (int i = 0; i < xrayWaterRed.Length; i++)
        {
            originWaterRed[i] = xrayWaterRed[i].GetComponent<MeshRenderer>().material;
            imageWaterRed[i] = xrayWaterRed[i].GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        if (script.isXrayActive)
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = facilities; }
            for (int i = 0; i < imageWaterBlue.Length; i++) { imageWaterBlue[i].material = waterBlue; }
            for (int i = 0; i < imageWaterRed.Length; i++) { imageWaterRed[i].material = waterRed; }
        }
        else
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = origin[i]; }
            for (int i = 0; i < imageWaterBlue.Length; i++) { imageWaterBlue[i].material = originWaterBlue[i]; }
            for (int i = 0; i < imageWaterRed.Length; i++) { imageWaterRed[i].material = originWaterRed[i]; }
        }
    }
}