using UnityEngine;

public class UnitLevelXrayMaterial : MonoBehaviour
{
    public Material change;

    private UnitLevelControl script;

    private GameObject[] xrayObject;
    private Material[] origin;
    private MeshRenderer[] image;

    private GameObject[] xrayEquipment;
    private Material[] equipmentOrigin;
    private MeshRenderer[] equipmentImage;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();

        xrayObject = GameObject.FindGameObjectsWithTag("Xray");
        origin = new Material[xrayObject.Length];
        image = new MeshRenderer[xrayObject.Length];
        for (int i = 0; i < xrayObject.Length; i++)
        {
            origin[i] = xrayObject[i].GetComponent<MeshRenderer>().material;
            image[i] = xrayObject[i].GetComponent<MeshRenderer>();
        }

        xrayEquipment = GameObject.FindGameObjectsWithTag("XrayUnit");
        equipmentOrigin = new Material[xrayEquipment.Length];
        equipmentImage = new MeshRenderer[xrayEquipment.Length];
        for (int i = 0; i < xrayEquipment.Length; i++)
        {
            equipmentOrigin[i] = xrayEquipment[i].GetComponent<MeshRenderer>().material;
            equipmentImage[i] = xrayEquipment[i].GetComponent<MeshRenderer>();
        }
    }

    void Update()
    {
        if (script.isXrayActive)
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = change; }
            for (int i = 0; i < equipmentImage.Length; i++) { equipmentImage[i].material = change; }
        }
        else
        {
            for (int i = 0; i < image.Length; i++) { image[i].material = origin[i]; }
            for (int i = 0; i < equipmentImage.Length; i++) { equipmentImage[i].material = equipmentOrigin[i]; }
        }
    }
}