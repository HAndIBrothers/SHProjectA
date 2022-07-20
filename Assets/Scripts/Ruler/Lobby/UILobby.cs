using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    public void Init()
    {
        Debug.LogWarning(":: UILobby : Initialise");

        this.InitProfile();
        this.InitTool();
        this.InitSector();
    }
    public void Open()
    {
        this.RenewLevel();
        this.RenewName();
        this.RenewPaidCoin();
        this.RenewFreeCoin();

        this.RenewProfileImage();
    }

    // >> Sector
    private Transform iSector;
    private void InitSector()
    {
        this.iSector = this.transform.Find("Section_Sector");
        this.InitButton_GameStart();
        this.InitButton_CollectionList();
        this.InitButton_ItemStore();
    }
    private Button iButton_GameStart = null;
    private void InitButton_GameStart()
    {
        this.iButton_GameStart = this.iSector.Find("Button_GameStart").GetComponent<Button>();
        this.iButton_GameStart.onClick.AddListener(() =>
        {
            App.oInstance.oDim.ShowDim(true, 1f, () =>
            {
                App.oInstance.oManagerScene.LoadScene(Enums.eScene.SELECT);
            });
        });
    }
    private Button iButton_CollectionList = null;
    private void InitButton_CollectionList()
    {
        this.iButton_CollectionList = this.iSector.Find("Button_CollectionList").GetComponent<Button>();
        this.iButton_CollectionList.onClick.AddListener(() =>
        {
            Debug.LogWarning(":: UILobby >> Collection List");
        });
    }
    private Button iButton_ItemStore = null;
    private void InitButton_ItemStore()
    {
        this.iButton_ItemStore = this.iSector.Find("Button_ItemStore").GetComponent<Button>();
        this.iButton_ItemStore.onClick.AddListener(() =>
        {
            Debug.LogWarning(":: UILobby >> Item Store");
        });
    }

    // >> Profile
    private Transform iProfile;
    private void InitProfile()
    {
        this.iProfile = this.transform.Find("Section_Profile");
        this.InitText_Level();
        this.InitText_Name();
        this.InitText_PaidCoin();
        this.InitText_FreeCoin();

        this.InitImage_ProfileImage();
    }
    private Text iLevel;
    private void InitText_Level()
    {
        this.iLevel = this.iProfile.Find("Section_Level").Find("Text_Level").GetComponent<Text>();
    }
    private void RenewLevel()
    {
        this.iLevel.text = string.Format("Lv. {0}", App.oInstance.oManagerPlayer.oLevel);
    }
    private Text iName;
    private void InitText_Name()
    {
        this.iName = this.iProfile.Find("Section_Name").Find("Text_Name").GetComponent<Text>();
    }
    private void RenewName()
    {
        this.iName.text = string.Format("{0}", App.oInstance.oManagerPlayer.oName);
    }
    private Text iPaidCoin;
    private void InitText_PaidCoin()
    {
        this.iPaidCoin = 
            this.iProfile.Find("Section_PaidCoin").Find("Text_PaidCoin").GetComponent<Text>();
    }
    private void RenewPaidCoin()
    {
        this.iPaidCoin.text = string.Format("{0:#,0}", App.oInstance.oManagerPlayer.oPaidCoin);
    }
    private Text iFreeCoin;
    private void InitText_FreeCoin()
    {
        this.iFreeCoin =
            this.iProfile.Find("Section_FreeCoin").Find("Text_FreeCoin").GetComponent<Text>();
    }
    private void RenewFreeCoin()
    {
        this.iFreeCoin.text = string.Format("{0:#,0}", App.oInstance.oManagerPlayer.oFreeCoin);
    }
    private Image iProfileImage;
    private void InitImage_ProfileImage()
    {
        this.iProfileImage =
            this.iProfile.Find("Section_ProfileImage").Find("Image_ProfileImage").GetComponent<Image>();
    }
    private void RenewProfileImage()
    {
        this.iProfileImage.sprite = App.oInstance.oManagerPlayer.oProfileImage;
    }

    // >> Tool
    private Transform iTool;
    private void InitTool()
    {
        this.iTool = this.transform.Find("Section_Tool");

        // :: Scenario
        this.InitButton_Setting();
        this.InitButton_Mail();
        this.InitButton_Scenario();
    }
    private Button iButton_Setting;
    private void InitButton_Setting()
    {
        this.iButton_Setting = this.iTool.Find("Button_Setting").GetComponent<Button>();
        this.iButton_Setting.onClick.AddListener(() =>
        {
            Debug.LogWarning(":: UILobby >> 설정창 열기");
        });
    }
    private Button iButton_Mail;
    private void InitButton_Mail()
    {
        this.iButton_Mail = this.iTool.Find("Button_Mail").GetComponent<Button>();
        this.iButton_Mail.onClick.AddListener(() =>
        {
            Debug.LogWarning(":: UILobby >> 메일창 열기");
        });
    }
    private Button iButton_Scenario;
    private void InitButton_Scenario()
    {
        this.iButton_Scenario = this.iTool.Find("Button_Scenario").GetComponent<Button>();
        this.iButton_Scenario.onClick.AddListener(() =>
        {
            Debug.LogWarning(":: UILobby >> 시나리오창 열기");
        });
    }

}
