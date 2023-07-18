using UnityEngine;

public class AlarmMaterialXray : MonoBehaviour
{
    public Material xray;

    private AlarmControl script;
    private Renderer renderer;
    private Material defaultMat;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMat = GetComponent<MeshRenderer>().material;
        script = GameObject.Find("EventSystem").GetComponent<AlarmControl>();
    }

    void Update()
    {
        if (script.isAlarm) { renderer.material = xray; }
        else { renderer.material = defaultMat; }
    }
}