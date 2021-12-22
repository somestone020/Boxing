using BestHTTP.WebSocket;
using System;
using System.Text;
using UnityEngine;

public class NetConnect : MonoBehaviour
{
    private WebSocket webSocket;
    private string _url;

    public NetConnect()
    {
        if (webSocket == null)
        {
            _url = NetDataModel.URL;
            Init(_url);
        }
    }
    public NetConnect(string url)
    {
        if (webSocket == null)
        {
            _url = url;
            Init(_url);
        }
    }

    private void Init(string url)
    {
        webSocket = new WebSocket(new Uri(url));
        webSocket.OnOpen += OnOpen;
        webSocket.OnMessage += OnMessageReceived;
        webSocket.OnError += OnError;
        webSocket.OnClosed += OnClosed;
    }

    private void AntiInit()
    {
        webSocket.OnOpen = null;
        webSocket.OnMessage = null;
        webSocket.OnError = null;
        webSocket.OnClosed = null;
        webSocket = null;
    }

    public void Connect()
    {
        webSocket.Open();
        Debug.Log("发送连接");
    }

    private byte[] getBytes(string message)
    {
        byte[] buffer = Encoding.Default.GetBytes(message);
        return buffer;
    }
    public void Send(string str)
    {
        webSocket.Send(str);
    }

    public void Close()
    {
        webSocket.Close();
    }
    void OnOpen(WebSocket ws)
    {
        Debug.Log("连接成功");

    }
    /// <summary>
    /// 接收信息
    /// </summary>
    /// <param name="ws"></param>
    /// <param name="msg">接收内容</param>
    void OnMessageReceived(WebSocket ws, string msg)
    {
        Debug.Log(msg);
        SetLog(msg);
    }

    private void SetLog(string msg)
    {

    }

    /// <summary>
    /// 关闭连接
    /// </summary>
    void OnClosed(WebSocket ws, UInt16 code, string message)
    {
        Debug.Log(message);
        setConsoleMsg(message);
        AntiInit();
        Init(_url);
    }

    private void setConsoleMsg(string message)
    {

    }

    private void OnDestroy()
    {
        if (webSocket != null && webSocket.IsOpen)
        {
            webSocket.Close();
            AntiInit();
        }
    }

    /// <summary>
    /// Called when an error occured on client side
    /// </summary>
    void OnError(WebSocket ws, Exception ex)
    {
        string errorMsg = string.Empty;
#if !UNITY_WEBGL || UNITY_EDITOR
        if (ws.InternalRequest.Response != null)
            errorMsg = string.Format("Status Code from Server: {0} and Message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);
#endif
        Debug.Log(errorMsg);
        setConsoleMsg(errorMsg);
        AntiInit();
        Init(_url);
    }
}
