using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using System;

public class LonginNet : MonoBehaviour
{
    private string url = "http://server.com/path";
    public HTTPRequest hTTPRequest;

    void Start()
    {
        hTTPRequest = new HTTPRequest(new Uri(url), HTTPMethods.Post, OnRequestFinished);
        

    }

    // Update is called once per frame
 

    void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        Debug.Log("Request Finished! Text received: " + response.DataAsText);
    }
}
