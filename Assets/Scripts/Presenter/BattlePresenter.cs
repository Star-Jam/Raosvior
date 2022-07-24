using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BattlePresenter : MonoBehaviour
{
    [SerializeField]
    BattleView _battleViewManager;

    [SerializeField]
    BattleModel _battleModel;

    bool _coroutineFlag = true;

    private void Start()
    {
        ViewSubscribe();
        ModelSubscribe();
    }


    private void ViewSubscribe()
    {
        _battleViewManager.SelectedObservable.Where(x => x.Item1).Subscribe(_ =>
        {
            StartCoroutine(_battleModel.WaitingForPreparation(_coroutineFlag));
            if (_coroutineFlag)
            {
                _coroutineFlag = false;
            }
        });
    }

    private void ModelSubscribe()
    {

    }
}
