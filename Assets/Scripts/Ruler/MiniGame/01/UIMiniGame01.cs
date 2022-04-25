using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniGame01 : MonoBehaviour
{
    public void Init()
    {
        this.AddButtonScenario_Start();

        this.Init_SectionBug();
    }

    // :: ¹ö±×
    [Header("Section")]
    public GameObject SECTION_Bug;
    private float iWidth_SectionBug;
    private float iHeight_SectionBug;
    private void Init_SectionBug()
    {
        Rect rect = this.SECTION_Bug.GetComponent<RectTransform>().rect;
        this.iWidth_SectionBug = rect.width;
        this.iHeight_SectionBug = rect.height;
    }
    public GameObject PREFAB_Bug;
    private Coroutine iCoroutine_Game;
    private void StartGame()
    {
        this.iCoroutine_Game = this.StartCoroutine(this.IENStartGame());
    }
    public void StopGame()
    {
        this.StopCoroutine(this.iCoroutine_Game);
    }
    [Range(1f, 5f)]
    public float oRespawnSecond = 1f;
    [Range(1f, 5f)]
    public float oDisappearSecond = 1f;
    private IEnumerator IENStartGame()
    {
        while(true)
        {
            // :: ±â¾î Å½»ö
            GameObject goBug 
                = Object.Instantiate<GameObject>(
                    this.PREFAB_Bug, this.transform);
            GearMiniGame01_Bug gearBug
                = goBug.GetComponent<GearMiniGame01_Bug>();

            // :: ·£´ý ÀÌ¹ÌÁö
            float randX = this.iWidth_SectionBug / 2f;
            float randY = this.iHeight_SectionBug / 2f;
            gearBug.Open(randX, randY, this.oDisappearSecond);

            // :: ·£´ý
            float waitRandom = Random.Range(0f, this.oRespawnSecond);
            yield return new WaitForSeconds(waitRandom);
        }
    }

    // :: ¹öÆ°
    [Header("Button")]
    public Button BUTTON_Start;
    private void AddButtonScenario_Start()
    {
        this.BUTTON_Start.onClick.AddListener(() =>
        {
            this.StartGame();
            this.BUTTON_Start.gameObject.SetActive(false);
        });
    }
}
