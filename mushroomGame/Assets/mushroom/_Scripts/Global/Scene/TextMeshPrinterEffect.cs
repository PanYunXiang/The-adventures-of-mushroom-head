using System.Collections;
using UnityEngine;

/// <summary>
/// TeshMesh组件的打字机效果
/// </summary>
[RequireComponent(typeof(TextMesh))]
class TextMeshPrinterEffect : MonoBehaviour
{
    /// <summary>
    /// 设置打字机效果
    /// </summary>
    /// <param name="content">要显示的内容</param>
    /// <param name="timeSpin">时间间隔</param>
    /// <returns></returns>
    public IEnumerator TpyerEffect(string content, float timeSpin, System.Action OnFinsih)
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        char[] strChar = content.ToCharArray();
        int i = 0;

        do
        {
            textMesh.text += strChar[i];
            yield return new WaitForSeconds(timeSpin);
            i++;
        } while (i < strChar.Length);
        if (i == strChar.Length)
        {
            OnFinsih();
        }
    }
}

