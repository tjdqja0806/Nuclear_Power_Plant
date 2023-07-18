using UnityEngine;
using VisualizationCore;

public class DataAgent : MonoBehaviour
{
    private float timer = 0.0f;
    [HideInInspector]
    public bool isAuto = true;

    void Start()
    {
        if (!isAuto) { DataService.Init(); }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 3.0f;
            if (!isAuto)
            {
                DataService.UpdateValues();
                //Debug.Log("2335-TBNSPD : " + DataService.GetSignalValueByTag("2235-TBNSPD").Value);
                //Debug.Log("2235-MPJ0001 : " + DataService.GetSignalValueByTag("2235-MPJ0001").Value);
            }
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------

    // 단일, 데이터만, Tag ID로
    public double getValueByTagID(string tagID)
    {
        return DataService.GetSignalValueByTag(tagID).Value;
    }

    // 단일, 데이터 및 단위, Tag ID로
    public string getValueAndUnitByTagID(string tagID)
    {
        return DataService.GetSignalValueByTag(tagID).Value + DataService.GetSignalValueByTag(tagID).Tag.EuUnit;
    }

    // 단일, 데이터만, Symbol Name으로
    public double getValueBySymbolName(string symbolName)
    {
        if (DataService.GetSignalValueBySymbol(symbolName) == null) { Debug.Log("SymbolName : " + symbolName); return 0; }
        return DataService.GetSignalValueBySymbol(symbolName).Value;
    }

    // 단일, 데이터 및 단위, Symbol Name으로
    public string getValueAndUnitBySymbolName(string symbolName)
    {
        return DataService.GetSignalValueBySymbol(symbolName).Value + DataService.GetSignalValueBySymbol(symbolName).Tag.EuUnit;
    }

    public void ClickWareHouse()
    {
        DataService.StartWareHouse();
    }
}