using UnityEngine;

public class PrimaryControl : MonoBehaviour
{
    [HideInInspector]
    public bool isXrayActive = false;

    // 클릭 시 X-Ray 상태 <-> 정상 상태
    public void _ChangeXrayActive() { isXrayActive = !isXrayActive; }
}