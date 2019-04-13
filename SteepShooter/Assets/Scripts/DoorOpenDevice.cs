using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    public Vector3 dpos;//Смещение, при открывании двери
    private bool _open;//переменаая да\нет для слежения за открытым состоянием двери


    public void Operate(){//открываем или закрываем дверь в зависимости от ее состояния
        if (_open){
        Vector3 pos = transform.position - dpos;
        transform.position = pos;
        } else{
            Vector3 pos = transform.position +dpos;
            transform.position = pos;
        }
        _open = !_open;
    }

    public void Activate()
    {
        if (!_open)
        { // Открывает дверь, только если она пока не открыта.
            Vector3 pos = transform.position + dpos;
            transform.position = pos;
            _open = true;
        }
    }
    public void Deactivate()
    {
        if (_open)
        { // Аналогично, закрывает дверь только при условии, что она уже не закрыта.
            Vector3 pos = transform.position - dpos;
            transform.position = pos;
            _open = false;
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
