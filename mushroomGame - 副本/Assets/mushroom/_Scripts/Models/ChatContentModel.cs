using System.Collections.Generic;

[System.Serializable]
public class ChatContents 
{
    public string id;
    public string teller;
    public string headImg;
    public string content;
}

[System.Serializable]
public class ChatList
{
    public List<ChatContents> ChatContentList;
    public List<ChatContents> OpenAnim;
}
