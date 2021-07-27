using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveCam : MonoBehaviour
{
    private Vector2?[] _touchPrePos = {null, null};
    private Vector2 _touchPreVector;
    private float _touchPreDist;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void LateUpdate()
    {
        if (Input.touchCount == 0)
        {
            _touchPrePos[0] = null;
            _touchPrePos[1] = null;
        }
        if(Input.touchCount == 1)
        {
            if (_touchPrePos[0] == null || _touchPrePos[1] != null)
            {
                _touchPrePos[0] = Input.GetTouch(0).position;
                _touchPrePos[1] = null; 
            }
            else
            {
                Vector2 touchNewPos = Input.GetTouch(0).position;
                transform.position += transform.TransformDirection((Vector3)((_touchPrePos[0] - touchNewPos) *
                    Camera.main.orthographicSize / Camera.main.pixelHeight * 2f));

                //MoveLimit();

                _touchPrePos[0] = touchNewPos;
            }
        }
        /*else if (Input.touchCount == 2)
        {
            if (_touchPrePos[1] == null)
            {
                _touchPrePos[0] = Input.GetTouch(0).position;
                _touchPrePos[1] = Input.GetTouch(1).position;;
                _touchPreVector = (Vector2) (_touchPrePos[0] - _touchPrePos[1]);
                _touchPreDist = _touchPreVector.magnitude;
            }
            else
            {
                Vector2 screen = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
                
                Vector2[] touchNewPos = { Input.GetTouch(0).position, Input.GetTouch(1).position};
                Vector2 touchNewVector = touchNewPos[0] - touchNewPos[1];
                float touchNewDist = touchNewVector.magnitude;
                
                transform.position += transform.TransformDirection((Vector3)((_touchPrePos[0] - _touchPrePos[1] - screen) *
                    Camera.main.orthographicSize / screen.y));

                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 3f);
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, 5f);

                _touchPrePos[0] = touchNewPos[0];
                _touchPrePos[1] = touchNewPos[1];
                _touchPreVector = touchNewVector;
                _touchPreDist = touchNewDist;
            }
        }*/
        else
        {
            return;
        }
    }

    void MoveLimit()
    {
        Vector3 temp;
        temp.x = Mathf.Clamp(transform.position.x, -1, 1);
        temp.y = Mathf.Clamp(transform.position.y, 5, 7);
        temp.z = Mathf.Clamp(transform.position.z, 10, 12);

        transform.position = temp;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
