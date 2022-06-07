using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMiniGame01_Result : MonoBehaviour
{
    public void Init()
    {
        this.AddButtonScenario_Retry();
        this.AddButtonScenario_EXIT();
    }
    public void Open()
    {
        App.oInstance.oManagerRuler.oMiniGame01.StartCoroutine(this.IENOpen());
        this.gameObject.SetActive(true);
    }
    private IEnumerator IENOpen()
    {
        var ruler = App.oInstance.oManagerRuler.oMiniGame01;
        // :: Log : 축하
        this.OpenLog(null, "개발자는 멋지게 버그를 잡았습니다.");
        // :: Log : 축하
        this.OpenLog(null, string.Format("총 {0} 점의 점수를 얻었습니다.",
            ruler.oScore));
        // :: Log : 기본금
        int addMoney = Mathf.FloorToInt(
            ruler.oScore * ruler.oData.oAddScore);
        this.OpenLog(null, string.Format("월급으로 {0} 원이 입금되었습니다.",
            addMoney));
        // :: Log : 추가금 : 공식 현재 없음
        int extraMoney = Mathf.FloorToInt(ruler.oScore / 500) * 100;
        this.OpenLog(null, string.Format("추가 수당 {0} 원이 더 들어왔습니다.",
            extraMoney));
        // :: Log : 총 금액
        int allMoney = addMoney + extraMoney;
        this.OpenLog(null, string.Format("통장에 총 {0} 원이 입금되었군요.",
            allMoney));
        App.oInstance.oManagerStatus.AddMoney(allMoney); // : 실제 추가
        // :: Log : 마지막 문구
        this.OpenLog(null, "개발자는 정말로 행복해졌습니다!");

        yield break;
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
    private void OpenLog(Sprite _sprite, string _text)
    {
        // :: 생성
        var goLog = Object.Instantiate<GameObject>(
            this.PREFAB_Log, this.oTRANSFORM_Logs);
        goLog.transform.SetAsLastSibling(); // : 마지막으로 보내기

        // :: 오픈
        goLog.GetComponent<GearMiniGame01_Result_Log>().Open(_sprite, _text);
    }

    // :: Buttons
    [Header("Buttons")]
    public Button BUTTON_Retry;
    private void AddButtonScenario_Retry()
    {
        this.BUTTON_Retry.onClick.AddListener(() =>
        {
            App.oInstance.oManagerRuler.oMiniGame01.Retry();
        });
    }
    public Button BUTTON_EXIT;
    private void AddButtonScenario_EXIT()
    {
        this.BUTTON_EXIT.onClick.AddListener(() =>
        {
            App.oInstance.oManagerScene.LoadScene(Enums.eScene.LOBBY);
        });
    }
}
