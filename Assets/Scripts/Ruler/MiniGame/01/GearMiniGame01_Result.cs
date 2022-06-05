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
        // :: Log : ����
        this.OpenLog(null, "�����ڴ� ������ ���׸� ��ҽ��ϴ�.");
        // :: Log : ����
        this.OpenLog(null, string.Format("�� {0} ���� ������ ������ϴ�.",
            ruler.oScore));
        // :: Log : �⺻��
        int addMoney = Mathf.FloorToInt(
            ruler.oScore * ruler.oData.oAddScore);
        this.OpenLog(null, string.Format("�������� {0} ���� �ԱݵǾ����ϴ�.",
            addMoney));
        // :: Log : �߰��� : ���� ���� ����
        int extraMoney = Mathf.FloorToInt(ruler.oScore / 500) * 100;
        this.OpenLog(null, string.Format("�߰� ���� {0} ���� �� ���Խ��ϴ�.",
            extraMoney));
        // :: Log : �� �ݾ�
        int allMoney = addMoney + extraMoney;
        this.OpenLog(null, string.Format("���忡 �� {0} ���� �ԱݵǾ�����.",
            allMoney));
        App.oInstance.oManagerStatus.AddMoney(allMoney); // : ���� �߰�
        // :: Log : ������ ����
        this.OpenLog(null, "�����ڴ� ������ �ູ�������ϴ�!");

        yield break;
    }
    public void Close()
    {
        // :: Log �ʱ�ȭ
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
        // :: ����
        var goLog = Object.Instantiate<GameObject>(
            this.PREFAB_Log, this.oTRANSFORM_Logs);
        goLog.transform.SetAsLastSibling(); // : ���������� ������

        // :: ����
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
