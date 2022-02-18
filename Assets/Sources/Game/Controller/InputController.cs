using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InputController : MonoBehaviour
    {
        private InputContext _InputContext;
        private float _time;
        private float _offsetX, _offsetY;
        private Vector2 _clickPos;
        // Start is called before the first frame update
        void Start()
        {
            _InputContext = Contexts.sharedInstance.input;
        }

        // Update is called once per frame
        void Update()
        {
            MouseCheck();
            TouchCheck();
        }

        private void TouchCheck()
        {
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero, 100);
                    if (hit.collider != null)
                    {
                        _clickPos = hit.transform.position;
                        _InputContext.ReplaceGameClick((int)hit.transform.position.x, (int)hit.transform.position.y);
                    }
                    _time = 0;
                    _offsetX = 0;
                    _offsetY = 0;
                }
                if (Input.touches[0].phase == TouchPhase.Moved)
                {
                    if (_time < 0.5f)
                    {
                        _time += Time.deltaTime;
                        _offsetX += Input.GetAxis("Mouse X");
                        _offsetY += Input.GetAxis("Mouse Y");
                    }
                    else
                    {
                        Slide();
                    }
                }
            }
        }
        private void MouseCheck()
        {
            //记录鼠标点击位置
            if (Input.GetMouseButtonDown(0))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
                if (hit.collider != null)
                {
                    _clickPos = hit.transform.position;
                    _InputContext.ReplaceGameClick((int)hit.transform.position.x, (int)hit.transform.position.y);
                }
                _time = 0;
                _offsetX = 0;
                _offsetY = 0;
            }

            //按住不松开
            if (Input.GetMouseButton(0))
            {
                _time += Time.deltaTime;
                _offsetX += Input.GetAxis("Mouse X");
                _offsetY += Input.GetAxis("Mouse Y");
            }

            //鼠标弹起 滑动操作 
            //时间<0.5s 0.1s误操作
            if (Input.GetMouseButtonUp(0) && _time < 0.5f && _time > 0.1f)
            {
                Slide();
            }
        }
        private void Slide()
        {
            SlideDirection direction = Mathf.Abs(_offsetX) > Mathf.Abs(_offsetY)
                ? _offsetX > 0 ? SlideDirection.RIGHT : SlideDirection.LEFT
                : _offsetY > 0 ? SlideDirection.UP : SlideDirection.DOWN;

            _InputContext.ReplaceGameSlide(new CustomVector2((int)_clickPos.x, (int)_clickPos.y), direction);
        }
    }
}

