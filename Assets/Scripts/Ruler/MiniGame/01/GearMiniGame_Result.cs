using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMiniGame_Result : MonoBehaviour
{
    public void Init()
    {
        this.AddButtonScenario_EXIT();
        this.Close();
    }
    public void MInit_Retry(System.Action _action)
    {
        this.BUTTON_Retry.onClick.AddListener(() =>
        {
            _action?.Invoke();
        });
    }
    public void Open()
    {
        this.gameObject.SetActive(true);
    }
    public void Close()
    {
        // :: Log 초기화
        while (this.oTRANSFORM_Logs.childCount > 0)
        {
            Object.DestroyImmediate(
                this.oTRANSFORM_Logs.GetChild(0).gameObject);
        }

        this.gameObject.SetActive(false);
    }

    // :: Logs
    [Header("Logs")]
    public Transform oTRANSFORM_Logs;
    public GameObject PREFAB_Log;
    public void OpenLog(Sprite _sprite, string _text)
    {
        // :: 생성
        var goLog = Object.Instantiate<GameObject>(
            this.PREFAB_Log, this.oTRANSFORM_Logs);
        goLog.transform.SetAsLastSibling(); // : 마지막으로 보내기

        // :: 오픈
        goLog.GetComponent<GearMiniGame_Result_Log>().Open(_sprite, _text);
    }

    // :: Buttons
    [Header("Buttons")]
    [SerializeField]
    private Button BUTTON_Retry;
    [SerializeField]
    private Button BUTTON_EXIT;
    private void AddButtonScenario_EXIT()
    {
        this.BUTTON_EXIT.onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(Enums.eScene.LOBBY);
        });
    }
}
