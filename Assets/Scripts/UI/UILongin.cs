using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using UnityEngine.SceneManagement;

public class UILongin : MonoBehaviour
{
    public InputField userName;
    public InputField password;
    public Toggle toggle;
    public Text readyText;
    private LonginNet longinNet;

    void Start()
    {
        longinNet = transform.parent.GetComponent<LonginNet>();
    }

    public string GetUserData()
    {
        return userName.text;
    }

    public void Login()
    {
        if (userName.text == "" || password.text == "") return;
        NetDataModel.LonginData data = new NetDataModel.LonginData(userName.text, password.text);
        //longinNet.hTTPRequest.AddField("longin", JsonMapper.ToJson(data));
        //longinNet.hTTPRequest.Send();
        LoadScene();
    }

    public void LoadScene()
    {
        GameObject go = new GameObject("NetClientManage");
        go.AddComponent<NetClientManage>();
        DontDestroyOnLoad(go);
        SceneManager.LoadScene("01_Game");
    }

    public void OnToggleEvent()
    {
        if (toggle.isOn) readyText.text = "已准备";
        else readyText.text = "请准备";
    }
}


