using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniGame02 : SHUI
{
    private RulerMiniGame02 iRuler;
    public override void Init(SHRuler _ruler)
    {
        // :: 룰러
        this.iRuler = (RulerMiniGame02)_ruler;

        // :: 초기화
        this.ShowButton_Start(true);

        // :: 버튼 시나리오
        this.AddButtonScenario_Start();
        this.AddButtonScenario_Controller();
    }
    [Header("Section")]
    public GameObject oSECTION_Bug;
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

        // :: 스크린 사이즈 확인
        Rect rect = this.oSECTION_Bug.GetComponent<RectTransform>().rect;
        float yPosition = rect.height / 2;
        yPosition += 300;
        float xPosition = rect.width / 2;

        while (true)
        {
            // :: 기어 탐색
            GameObject goBug
                = Object.Instantiate<GameObject>(
                    this.PREFAB_Bug, this.oSECTION_Bug.transform);
            GearMiniGame02_Bug gearBug
                = goBug.GetComponent<GearMiniGame02_Bug>();

            // :: 랜덤 이미지
            float randX = Random.Range(-xPosition, xPosition);
            gearBug.Open(randX, yPosition);

            // :: 랜덤
            yield return new WaitForSeconds(0.5f);
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
    [Header("컨트롤러")]
    public Image IMAGE_Player;
    public GearMiniGame02_Controller BUTTON_Left;
    public GearMiniGame02_Controller BUTTON_Right;
    private Coroutine iCoroutine_LeftAction = null;
    private float iMoveSpeed = 2f;
    private IEnumerator IENActionLeft()
    {
        while (true)
        {
            var transform = this.IMAGE_Player.transform;
            
            transform.position 
                -= new Vector3(Time.deltaTime, 0) * this.iMoveSpeed;

            if(transform.localPosition.x < -this.iSizeHalf)
            {
                transform.localPosition = new Vector3(
                    -this.iSizeHalf, transform.localPosition.y,
                    transform.localPosition.z);
            }

            yield return null;
        }
    }
    private IEnumerator IENActionRight()
    {
        while(true)
        {
            var transform = this.IMAGE_Player.transform;

            transform.position
                += new Vector3(Time.deltaTime, 0) * this.iMoveSpeed;

            if (transform.localPosition.x > this.iSizeHalf)
            {
                transform.localPosition = new Vector3(
                    this.iSizeHalf, transform.localPosition.y,
                    transform.localPosition.z);
            }

            yield return null;
        }
    }
    private Coroutine iCoroutine_RightAction = null;
    private float iSizeHalf = 0;
    private void AddButtonScenario_Controller()
    {
        // :: 사이즈 등록
        Transform parent = this.IMAGE_Player.transform.parent;
        this.iSizeHalf 
            = parent.GetComponent<RectTransform>().rect.width / 2;

        // :: Left 컨트롤러
        this.BUTTON_Left.Init(() =>
        {
            this.iCoroutine_LeftAction 
                = this.StartCoroutine(this.IENActionLeft());
        }, () =>
        {
            if(this.iCoroutine_LeftAction != null)
            {
                this.StopCoroutine(this.iCoroutine_LeftAction);
                this.iCoroutine_LeftAction = null;
            }
        });

        // :: Right 컨트롤러
        this.BUTTON_Right.Init(() =>
        {
            this.iCoroutine_RightAction
                = this.StartCoroutine(this.IENActionRight());
        }, () =>
        {
            if (this.iCoroutine_RightAction != null)
            {
                this.StopCoroutine(this.iCoroutine_RightAction);
                this.iCoroutine_RightAction = null;
            }
        });
    }
}
