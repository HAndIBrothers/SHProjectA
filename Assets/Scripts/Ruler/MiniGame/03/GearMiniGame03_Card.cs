using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearMiniGame03_Card : MonoBehaviour
{
    private Image iImage;
    public void Init()
    {
        this.iImage = this.GetComponent<Image>();

        // :: Set Button Scenario
        this.AddButtonScenario();
    }
    private void AddButtonScenario()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            App.oInstance.oManagerRuler
            .oMiniGame03.ClickCard(this.oID, this.oValue);
        });
    }

    [Header("Text")]
    [SerializeField]
    private Text TEXT_Value;
    public int oID { get; private set; }
    public int oValue { get; private set; }
    public Enums.MiniGame03.Card.eStatus oStatus { get; private set; } 
        = Enums.MiniGame03.Card.eStatus.NONE;
    public void Open(int _id, int _value)
    {
        this.oID = _id;
        this.oValue = _value;

        this.SetStatus(Enums.MiniGame03.Card.eStatus.OPEN);
    }
    public void SetStatus(Enums.MiniGame03.Card.eStatus _eStatus)
    {
        // :: EXIT : 같은 것일 때
        if (this.oStatus == _eStatus) return;

        this.oStatus = _eStatus;
        switch(_eStatus)
        {
            case Enums.MiniGame03.Card.eStatus.OPEN:
                this.iImage.color = Color.green;
                break;
            case Enums.MiniGame03.Card.eStatus.CLOSE:
                this.iImage.color = Color.red;
                break;
            case Enums.MiniGame03.Card.eStatus.SELECT:
                this.iImage.color = Color.yellow;
                break;
        }
    }
    public void ShowValue()
    {
        this.TEXT_Value.text = this.oValue.ToString();
    }
}
