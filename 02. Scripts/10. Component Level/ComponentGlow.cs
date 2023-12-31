﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComponentGlow : MonoBehaviour
{
    [Serializable]
    public struct glow
    {
        public Transform drag;
        public Transform auto;
    }
    [SerializeField]
    public glow[] glowEquipment;
    public Color color;
    private int status = -1;
    private bool isClick = false;
    private void Update()
    {
        if(status == -1)
        {
            for(int i=0; i< glowEquipment.Length; i++)
            {
                SetLayersRecursively(glowEquipment[i].drag, "Default");
                SetLayersRecursively(glowEquipment[i].auto, "Default");
            }
        }
        else
        {
            for (int i = 0; i < glowEquipment.Length; i++)
            {
                if (i != status)
                {
                    SetLayersRecursively(glowEquipment[i].drag, "Default");
                    SetLayersRecursively(glowEquipment[i].auto, "Default");
                }
                else
                    SetLayersRecursively(glowEquipment[status].drag, "Glow");
                    SetLayersRecursively(glowEquipment[status].auto, "Glow");
            }
        }
        //if (isClick)
        //    SetLayersRecursively(plant, "Glow");
        //else
        //    SetLayersRecursively(plant, "Default");
    }
    public void Click(int num)
    {
        status = num - 1;
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
            propertyBlock.SetColor("_SelectionColor", color);
            rndr.SetPropertyBlock(propertyBlock);
        }
    }
}
