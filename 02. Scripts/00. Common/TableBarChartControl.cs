using ChartAndGraph;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TableBarChartControl : MonoBehaviour
{
    [Serializable]
    public struct GraphStruct
    {
        public TextMeshProUGUI sk3Data;
        public TextMeshProUGUI sk4Data;
        public Image button;
        public TextMeshProUGUI text;
    }

    [Serializable]
    public struct DateStruct
    {
        public Image button;
        public CanvasGroup cg;
        public BarChart bar;
    }

    [Header("Graph Attribute")]
    public GraphStruct[] graphStructs;
    [Space]
    public GameObject dropdown;
    public Sprite graphNormal;
    public Sprite graphSelected;
    public TextMeshProUGUI barChartTitle;

    [Header("Date Attribute")]
    public DateStruct[] dateStructs;
    [Space]
    public Sprite dateNormal;
    public Sprite dateSelected;

    [Space]
    public bool unit3 = true;
    public bool unit4 = true;
    [Space]
    public GameObject window;

    private float timer = 0.0f;
    private int graphIndex = 0;
    private int dateIndex = 0;
    private bool isDropdown = false;

    void Start() { }

    void Update()
    {
        barChartTitle.text = TitleModify();
        for (int i = 0; i < dateStructs.Length; i++)
        {
            if (i == dateIndex) { dateStructs[i].cg.alpha = 1; }
            else { dateStructs[i].cg.alpha = 0; }
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1.0f;
            ChangeData();
        }
    }

    private string TitleModify()
    {
        string date = "";
        string graph = "";

        switch (dateIndex)
        {
            case 0:
                date = "Day";
                break;
            case 1:
                date = "Week";
                break;
            case 2:
                date = "Month";
                break;
            case 3:
                date = "Year";
                break;
        }

        switch (graphIndex)
        {
            case 0:
                graph = "R-PAS";
                break;
            case 1:
                graph = "PHI";
                break;
            case 2:
                graph = "APD";
                break;
            case 3:
                graph = "PI";
                break;
            case 4:
                graph = "Total";
                break;
        }

        return date + " " + graph + " History";
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    public void _ClickGraph(int num)
    {
        graphIndex = num;
        ChangeData();
    }

    public void _ClickDate(int num)
    {
        dateIndex = num;
        ChangeData();
    }

    public void _ClickDropdown()
    {
        isDropdown = !isDropdown;
        dropdown.SetActive(isDropdown);
    }

    public void _ClickWindow(bool active) { window.SetActive(active); }

    private void ChangeData()
    {
        switch (dateIndex)
        {
            case 0:
                for (int i = 1; i < 5; i++) { dateStructs[0].bar.DataSource.SetValue(i + "", "All", randomValue(0, 999)); }
                break;

            case 1:
                for (int i = 1; i < 8; i++) { dateStructs[1].bar.DataSource.SetValue(i + "", "All", randomValue(0, 999)); }
                break;

            case 2:
                for (int i = 1; i < 5; i++) { dateStructs[2].bar.DataSource.SetValue(i + "", "All", randomValue(0, 999)); }
                break;

            case 3:
                for (int i = 1; i < 13; i++) { dateStructs[3].bar.DataSource.SetValue(i + "", "All", randomValue(0, 999)); }
                break;
        }

        for (int i = 0; i < dateStructs.Length; i++)
        {
            if (i == dateIndex) { dateStructs[i].button.sprite = dateSelected; }
            else { dateStructs[i].button.sprite = dateNormal; }
        }

        for (int i = 0; i < graphStructs.Length; i++)
        {
            if (i == graphIndex)
            {
                graphStructs[i].button.sprite = graphSelected;
                graphStructs[i].text.color = Color.black;
            }
            else
            {
                graphStructs[i].button.sprite = graphNormal;
                graphStructs[i].text.color = Color.white;
            }
        }

        for (int i = 0; i < graphStructs.Length; i++)
        {
            if (unit3) { graphStructs[i].sk3Data.text = string.Format("{0:0}", randomValue(0, 999)) + ""; }
            else { graphStructs[i].sk3Data.text = "-"; }
            if (unit4) { graphStructs[i].sk4Data.text = string.Format("{0:0}", randomValue(0, 999)) + ""; }
            else { graphStructs[i].sk4Data.text = "-"; }
        }
    }
}