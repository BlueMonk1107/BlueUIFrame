using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PopFromUI : AUIEffect {
    private Vector3 sourcePosition;
    public override void Enter(IPara para)
    {
        SetSourcePosition();
        RectTrans.position = sourcePosition;
        RectTrans.localScale = Vector3.zero;
        RectTrans.DOLocalMove(Vector3.zero, UIEffectTime.POP_FROM_UI);
        RectTrans.DOScale(1, UIEffectTime.POP_FROM_UI);
    }

    public override void Exit(IPara para)
    {
        RectTrans.DOMove(sourcePosition, UIEffectTime.POP_FROM_UI);
        RectTrans.DOScale(0, UIEffectTime.POP_FROM_UI).OnComplete(() =>
        {
            OnExitComplete(para);
        });
    }

    private void SetSourcePosition()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            sourcePosition = EventSystem.current.currentSelectedGameObject.transform.position;
        }
        else
        {
            sourcePosition = RectTrans.position;
        }
    }
}
