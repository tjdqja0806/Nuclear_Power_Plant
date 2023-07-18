using UnityEngine;

public class ServerLevelControl : MonoBehaviour
{
    public Transform level;
    //private double scale;
    private Renderer material;

    public PieChartScript script;

    private Material origin;
    public Material ghost;

    private ServerXrayMaterial xrayScript;
    // Start is called before the first frame update
    void Start()
    {
        xrayScript = GameObject.Find("EventSystem").GetComponent<ServerXrayMaterial>();
        material = level.GetComponent<Renderer>();
        origin = material.material;
    }

    void Update()
    {
        level.localScale = new Vector3(1f, (float)script.value * 0.01f, 1f);
        if (xrayScript.isChange)
        {
            material.material = ghost;
            if (level.localScale.y >= 0.8)
                material.material.SetColor("_FresnelColor", Color.red);
            else if (level.localScale.y >= 0.5)
                material.material.SetColor("_FresnelColor", Color.yellow);
            else if (level.localScale.y <= 0.5)
                material.material.SetColor("_FresnelColor", Color.green);
        }
        else
        {
            material.material = origin;
        }
    }
}
