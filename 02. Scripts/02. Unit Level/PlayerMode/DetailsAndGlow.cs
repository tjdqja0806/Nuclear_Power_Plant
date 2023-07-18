using UnityEngine;

public class DetailsAndGlow : MonoBehaviour
{
    public string equipmentName = "";
    private DetailInfoControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<DetailInfoControl>();
    }

    void Update()
    {
        if (script.nameString.Equals(equipmentName) && script.isActive)
        {
            SetLayersRecursively(transform, "Glow");
        }
        else
        {
            SetLayersRecursively(transform, "Equipment");
        }
    }

    private void SetLayersRecursively(Transform trans, string name)
    {
        SetColorRecursively(trans);
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            SetColorRecursively(child);
            SetLayersRecursively(child, name);
        }
    }

    private void SetColorRecursively(Transform trans)
    {
        var rndr = trans.GetComponent<Renderer>();
        if (rndr != null)
        {
            var propertyBlock = new MaterialPropertyBlock();
            rndr.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_SelectionColor", Color.white);
            rndr.SetPropertyBlock(propertyBlock);
        }
    }
}