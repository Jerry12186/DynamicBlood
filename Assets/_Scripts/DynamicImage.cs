using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;


/// <summary>
/// Create By Jerry 2018.5.7
/// 有两种方法实现动态血条
/// 一种是通过使用DoTween动画控制Image的Scale，注意：此方法需要将Image的Pivot调成0，0
/// 另外一种，通过调节fillAmount来实现
/// </summary>
public class DynamicImage : MonoBehaviour
{
    public Image img;
    /// <summary>
    /// DoTween方法
    /// 需要判断当前血量是总血量的的多少，然后把位置传过去
    /// </summary>
    /// <param name="img"></param>
    /// <param name="pos">移动到的位置</param>
    /// <param name="time">需要的时间</param>
    private static Queue<float> numQueue = new Queue<float>();
    private static bool bPlaying = false;
    public static void MoveImageByFillAmount(Image img, float pos, float time = 0.5f)
    {
        if (bPlaying)
        {
            numQueue.Enqueue(pos);
            return;
        }
        bPlaying = true;

        DOTween.To(
            () => img.fillAmount,
            (v) => img.fillAmount = v,
            pos,
            time
            ).SetEase(Ease.OutSine).OnComplete(
                () => 
                {
                    bPlaying = false;
                    if (numQueue.Count > 0)
                    {
                        MoveImageByFillAmount(img, numQueue.Dequeue());
                    }
                }
            );
    }
}
