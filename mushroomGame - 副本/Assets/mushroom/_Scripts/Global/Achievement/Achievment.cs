using UnityEngine;
using UnityEngine.UI;

class Achievment : MonoBehaviour
{
    /// <summary>
    /// 成就头像
    /// </summary>
    private Sprite img;

    /// <summary>
    /// 成就名字
    /// </summary>
    private new string name;

    /// <summary>
    /// 成就描述
    /// </summary>
    private string descriable;

    /// <summary>
    /// 获得成就时候的时间
    /// </summary>
    private string time;

    /// <summary>
    /// 设置成就UI界面
    /// </summary>
    /// <param name="img"></param>
    /// <param name="name"></param>
    /// <param name="descriable"></param>
    public void SetInfo(string img, string name, string descriable,string time)
    {
        if (img == "" || name == "" || descriable == "") return;
        this.img = Resources.Load<Sprite>(VariablePath.Image_Achievement + img);
        this.name = name;
        this.descriable = descriable;
        this.time = time;

        SetContent();
    }

    private void SetContent()
    {
        transform.Find("Image").GetComponent<Image>().sprite = img;
        transform.Find("Name").GetComponent<Text>().text = name;
        transform.Find("Descriable").GetComponent<Text>().text = descriable;
        transform.Find("Time").GetComponent<Text>().text = time;
    }
}

