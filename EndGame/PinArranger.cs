using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinArranger : MonoBehaviour
{
    Vector3 _startPos;
    [SerializeField] GameObject _pin;
    [SerializeField] float _xOffset, _zOffset, _scaleFactor;
    [SerializeField] int _count;


    public void StartArrange(int count)
    {
        ArrangePins(count);
    }

    void ArrangePins(int count)
    {

        _startPos = transform.position;

        int row = 0;
        while (count > 0)
        {
            int emptyRow = row;
            while(emptyRow >= 0 && count > 0)
            {
                GameObject pin = Instantiate(_pin, new Vector3(_startPos.x + (_xOffset * row) * 2f, _startPos.y, (_startPos.z - (_zOffset * emptyRow ) * 2f) + (_startPos.z + (_zOffset * row ) * 2f) / 2 ), _pin.transform.rotation);
                pin.transform.localScale = new Vector3(250 +  row * _scaleFactor, 250 + row * _scaleFactor, 250 + row * _scaleFactor);
                pin.transform.parent = transform;
                pin.gameObject.layer = LayerMask.NameToLayer("ENDGAME PINS");
                emptyRow--;

                count--;
            }
            row++;
        }
    }
}
