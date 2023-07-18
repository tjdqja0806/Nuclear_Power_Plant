using UnityEngine;

public class XRayParticle : MonoBehaviour
{
    public GameObject particle;

    private PrimaryControl script;

    void Start() { script = GameObject.Find("EventSystem").GetComponent<PrimaryControl>(); }

    void Update() { particle.SetActive(script.isXrayActive); }
}