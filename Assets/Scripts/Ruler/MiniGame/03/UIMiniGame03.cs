using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMiniGame03 : SHUI
{

    private RulerMiniGame03 iRuler;
    public override void Init(SHRuler _ruler)
    {
        // :: Save Ruler
        this.iRuler = (RulerMiniGame03)_ruler;

        // :: Cards
        this.Init_Cards();
    }

    private struct sCard
    {
        public sCard(int _id, GearMiniGame03_Card _card, int _value)
        {
            this.oID = _id;
            this.oGear = _card;

            // :: Set Value
            this.oValue = _value;
            this.oGear.Open(this.oID, this.oValue);
        }

        public int oID { get; private set; }
        public GearMiniGame03_Card oGear { get; private set; }
        public int oValue { get; private set; }
    }
    [Header("Cards")]
    [SerializeField]
    private Transform SECTION_Cards;
    private Dictionary<int, sCard> iCards;
    private void Init_Cards()
    {
        // :: Init
        this.iCards = new Dictionary<int, sCard>();

        // :: Set
        for(int index = 0; index < this.SECTION_Cards.childCount; index++)
        {
            GearMiniGame03_Card gear
                = this.SECTION_Cards.GetChild(index)
                .GetComponent<GearMiniGame03_Card>();

            if(gear != null)
            {
                // :: Set Gear
                gear.Init();
                sCard card = new sCard(index, gear, 
                    Mathf.FloorToInt(index / 2));
                card.oGear.ShowValue();
                this.iCards.Add(card.oID, card);
            }
        }
    }
}
