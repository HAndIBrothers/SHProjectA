using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniGame02 : MonoBehaviour
{
    public void Init()
    {
        // :: 초기화
        this.ShowButton_Start(true);

        // :: 버튼 시나리오
        this.AddButtonScenario_Start();
    }
    [Header("Section")]
    public GameObject oSECTION_Bug;
    private float iWidth_SectionBug;
    private float iHeight_SectionBug;
    private void Init_SectionBug()
    {
        Rect rect = this.oSECTION_Bug.GetComponent<RectTransform>().rect;
        this.iWidth_SectionBug = rect.width;
        this.iHeight_SectionBug = rect.height;
    }
    [Header("Bug")]
    public GameObject PREFAB_Bug;
    private Coroutine iCoroutine_SpawnBugs;
    public void Start_SpawnBugs()
    {
        this.iCoroutine_SpawnBugs = App.oInstance.oManagerRuler.oMiniGame02
            .StartCoroutine(this.IENSpawnBugs());
    }
    public void Stop_SpawnBugs()
    {
        App.oInstance.oManagerRuler.oMiniGame02
            .StopCoroutine(this.iCoroutine_SpawnBugs);
    }
    private IEnumerator IENSpawnBugs()
    {
        // :: 초기화
        while (this.oSECTION_Bug.transform.childCount > 0)
        {
            Object.Destroy(this.oSECTION_Bug.transform.GetChild(0).gameObject);
        }

        while (true)
        {
            // :: 기어 탐색
            GameObject goBug
                = Object.Instantiate<GameObject>(
                    this.PREFAB_Bug, this.oSECTION_Bug.transform);
            GearMiniGame02_Bug gearBug
                = goBug.GetComponent<GearMiniGame02_Bug>();

            // :: 랜덤 이미지
            float randX = this.iWidth_SectionBug / 2f;
            float randY = this.iHeight_SectionBug / 2f;
            gearBug.Open(randX, randY);

            Debug.LogWarning("Aaaa");

            // :: 랜덤
            //float waitRandom = Random.Range(0f, this.oRespawnSecond);
            yield return new WaitForSeconds(1);
        }
    }

    [Header("버튼")]
    public Button BUTTON_Start;
    private void ShowButton_Start(bool _check)
    {
        this.BUTTON_Start.gameObject.SetActive(_check);
    }
    private void AddButtonScenario_Start()
    {
        this.BUTTON_Start.onClick.AddListener(() =>
        {
            App.oInstance.oManagerRuler.oMiniGame02.StartGame();
            this.ShowButton_Start(false);
        });
    }
}
