using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatContent : MonoBehaviour
{
    const string Img_Path = "Images/OpenAnim/";
 
    [SerializeField]
    private Image headImage;
    [SerializeField]
    private Text content;

    void Start()
    {
        //this.content.text = "";
    }

    public void SetContent(string imagePath,string content)
    {
        headImage.sprite = Resources.Load<Sprite>(Img_Path + imagePath);
        this.content.text = content;
    }
}