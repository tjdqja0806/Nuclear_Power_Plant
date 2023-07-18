using UnityEngine;
using UnityEngine.UI;

public class MaterialControl : MonoBehaviour
{
    public Material waterBlue;
    public Material waterRed;
    [Space]
    public Slider slider;
    public bool isTemp = false;
    public bool isFlow = false;

    private float sliderValue;

    void Update()
    {
        sliderValue = slider.value;
        if (isTemp)
        {
            waterBlue.SetFloat("Blending", calculateRate(0, 100, sliderValue));  // float : 0 ~ 1
            waterRed.SetFloat("Blending", calculateRate(0, 100, sliderValue));  // float : 0 ~ 1
        }
        if (isFlow)
        {
            waterBlue.SetFloat("Flow_Speed", calculateRate(0, 100, sliderValue));  // float : 0 ~ 1
            waterRed.SetFloat("Flow_Speed", calculateRate(0, 100, sliderValue));  // float : 0 ~ 1
        }
    }

    // Return : 0 ~ 1
    private float calculateRate(float min, float max, float value) { return (float)((value - min) / (max - min)); }
}