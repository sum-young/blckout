using UnityEngine;
using UnityEngine.UI;

public class MicUI : MonoBehaviour
{   
    [Header("UI 이미지 연결")]
    [SerializeField] private Image micOn;
    [SerializeField] private Image micOff;

    public void SetMicUI(bool status)
    {
        micOn.gameObject.SetActive(status);
        micOff.gameObject.SetActive(!status);
    }
}
