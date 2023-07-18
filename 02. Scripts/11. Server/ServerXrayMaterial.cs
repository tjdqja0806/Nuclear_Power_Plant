using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerXrayMaterial : MonoBehaviour
{
    [HideInInspector]
    public bool isChange;
    public Material change;

    private GameObject[] xrayObject;
    private Material[] origin;
    private MeshRenderer[] renderer;

    private float timer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        xrayObject = GameObject.FindGameObjectsWithTag("Xray");
        origin = new Material[xrayObject.Length];
        renderer = new MeshRenderer[xrayObject.Length];
        for (int i = 0; i < xrayObject.Length; i++)
        {
            origin[i] = xrayObject[i].GetComponent<MeshRenderer>().material;
            renderer[i] = xrayObject[i].GetComponent<MeshRenderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            for (int i = 0; i < renderer.Length; i++)
            {
                xrayObject[i].gameObject.transform.localScale = new Vector3(1f, randomValue(0, 100) * 0.01f, 1f);
                timer = 1f;
            }
        }
        if (isChange)
        {
            for (int i = 0; i < renderer.Length; i++)
            {
               
                renderer[i].material = change;
                if (xrayObject[i].gameObject.transform.localScale.y >= 0.8)
                    renderer[i].material.SetColor("_FresnelColor", Color.red);
                else if (xrayObject[i].gameObject.transform.localScale.y >= 0.5)
                    renderer[i].material.SetColor("_FresnelColor", Color.yellow);
                else if (xrayObject[i].gameObject.transform.localScale.y <= 0.5)
                    renderer[i].material.SetColor("_FresnelColor", Color.green);
            }

        }
        else
        {
            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].material = origin[i];
            }

        }
    }

    public void Xray()
    {
        isChange = !isChange;
    }
    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}
