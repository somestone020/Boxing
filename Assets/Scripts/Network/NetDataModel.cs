using System;
using System.Collections;
using System.Collections.Generic;

public class NetDataModel
{
    public const string URL = "ws://10.39.1.150:8080/api/websocket/100";

    public class LonginData
    {
        public string user;
        public string password;

        public LonginData() { }
        public LonginData(string _user, string _password)
        {
            user = _user;
            password = _password;
        }

       
    }

    public class PlayerCommand
    {
        public string commandName;
        public int commandNum;
    }

    public class NetReceivedModel
    {
        public int id;
        public int fpsNumber;
        public string playerName;
        public List<PlayerCommand> playerCommands;
    }
}
