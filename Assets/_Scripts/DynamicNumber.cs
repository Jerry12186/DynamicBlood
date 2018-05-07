using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class DynamicNumber
{
    /// <summary>
    /// 动态改变数字
    /// </summary>
    /// <param name="text">显示数字的文本，暂时只支持int动态变化</param>
    /// <param name="addNum">添加的数，支持负数</param>
    private static Queue<int> numQueue = new Queue<int>();
    private static bool bPlaying = false;
    public static void ChangeNum(Text text, int addNum)
    {
        if (bPlaying)
        {
            numQueue.Enqueue(addNum);
            return;
        }
        bPlaying = true;

        DOTween.To(
                () => float.Parse(text.text),
                (v) => text.text = v.ToString("0"),
                int.Parse(text.text) + addNum,
                1
            ).OnComplete(
                () =>
                {
                    bPlaying = false;
                    if (numQueue.Count > 0)
                    {
                        ChangeNum(text, numQueue.Dequeue());
                    }
                }
            );
    }
}