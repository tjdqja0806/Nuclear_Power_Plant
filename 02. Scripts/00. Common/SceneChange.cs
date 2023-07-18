using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void click(int index) { AutoFade.LoadLevel(index, 0.5f, 0.5f, Color.black); }
    public void clickString(string index) { AutoFade.LoadLevel(index, 0.5f, 0.5f, Color.black); }
}
