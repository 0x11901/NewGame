﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private enum Direction
    {
        Self,
        Top,
        Left,
        Right
    }

    [SerializeField] private GameObject _designTemplateLeft;
    [SerializeField] private GameObject _designTemplateTop;
    [SerializeField] private GameObject _designTemplateRight;
    [SerializeField] private GameObject _designTemplateSelf;

    [SerializeField] private GameObject _handsLeft;
    [SerializeField] private GameObject _handsTop;
    [SerializeField] private GameObject _handsRight;

    [SerializeField] private GameObject _hand;

    private Vector3 _size;
    private byte _no;
    private byte _total;
    private List<GameObject> _riverCard;
    private List<byte> _cards;
    private byte _lr;
    private byte _tr;
    private byte _rr;
    private byte _sr;

    private Vector3 GetObjectSize(GameObject go)
    {
        var realSize = Vector3.zero;

        var mesh = go.GetComponent<MeshFilter>().sharedMesh;
        if (mesh == null)
        {
            return realSize;
        }

        var meshSize = mesh.bounds.size;
        var scale = transform.lossyScale;
        realSize = new Vector3(meshSize.x * scale.x, meshSize.y * scale.y, meshSize.z * scale.z);

        return realSize;
    }

    private void Awake()
    {
        _total = 136;
        _no = 0;
        _riverCard = new List<GameObject>(120);
        _cards = new List<byte>()
        {
            11, 12, 13, 14, 15, 16, 17, 18, 19, 11, 12, 13, 14, 15, 16, 17, 18, 19, 11, 12, 13, 14, 15, 16, 17, 18,
            19, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 23, 24, 25, 26, 27, 28, 29, 21, 22, 23, 24, 25, 26, 27,
            28, 29, 21, 22, 23, 24, 25, 26, 27, 28, 29, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 34, 35, 36,
            37, 38, 39, 31, 32, 33, 34, 35, 36, 37, 38, 39, 31, 32, 33, 34, 35, 36, 37, 38, 39, 31, 32, 33, 34, 35,
            36, 37, 38, 39, 41, 42, 43, 44, 45, 46, 47, 41, 42, 43, 44, 45, 46, 47, 41, 42, 43, 44,
            45, 46, 47, 41, 42, 43, 44, 45, 46, 47
        };
        _lr = 0;
        _tr = 0;
        _rr = 0;
        _sr = 0;
    }

    public void ShowRiver()
    {
        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateLeft);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                card.name = (++_no).ToString();

                var startPosition = _designTemplateLeft.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z + i * _size.x);

                _riverCard.Add(card);
            }
        }

        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateTop);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                card.name = (++_no).ToString();

                var startPosition = _designTemplateTop.transform.position;
                card.transform.position = new Vector3(startPosition.x + i * _size.x, startPosition.y + j * _size.y,
                    startPosition.z);

                _riverCard.Add(card);
            }
        }

        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateRight);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                card.name = (++_no).ToString();

                var startPosition = _designTemplateRight.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z - i * _size.x);

                _riverCard.Add(card);
            }
        }

        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateSelf);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                card.name = (++_no).ToString();

                var startPosition = _designTemplateSelf.transform.position;
                card.transform.position = new Vector3(startPosition.x - i * _size.x, startPosition.y + j * _size.y,
                    startPosition.z);

                _riverCard.Add(card);
            }
        }

        StartCoroutine(Foo());
    }

    private IEnumerator Foo()
    {
        yield return new WaitForSeconds(1);
        _total = 84;
        ShowHands();
        var rand = new System.Random();
        var d = new List<Direction>() {Direction.Self, Direction.Right, Direction.Top, Direction.Left};
//        for (var i = 0; i < 4; i++)
//        {
//            var index = rand.Next(_cards.Count);
//            var any = _cards[index];
//            yield return Play(d[i], any);
//            _cards.RemoveAt(any);
//            yield return new WaitForSeconds(1.5f);
//        }
        var index = rand.Next(_cards.Count);
        var any = _cards[index];

        StartCoroutine(Play(Direction.Self, any));

        _cards.RemoveAt(any);
    }

    private IEnumerator Play(Direction direction, byte card)
    {
        switch (direction)
        {
            case Direction.Self:
                var hand = Instantiate(_hand);
                var handAnimation = hand.GetComponent<Animation>();
                handAnimation.wrapMode = WrapMode.Once;
                var t = hand.transform.position;
                hand.transform.position = new Vector3(t.x + _size.x * (_sr % 6), t.y, t.z - _size.z * (_sr / 6));
                var v = new Vector3(-0.087f + _size.x * (_sr % 6), 0.1117f, -0.0258f - _size.z * (_sr / 6));
                ++_sr;

                yield return Bar("Prefabs/" + card.ToString(), v,
                    Quaternion.Euler(new Vector3(-0.052f, -0.142f, 177.683f)),
                    1.0f);

                yield return new WaitForSeconds(handAnimation.clip.length);
                Destroy(hand);

                yield return new WaitForSeconds(handAnimation.clip.length);
                Destroy(hand);
                break;
            case Direction.Top:
                var hand3 = Instantiate(_hand, new Vector3(0.139f, 0.036f, 0.152f),
                    Quaternion.Euler(new Vector3(0f, 180.0f, 0f)));

                var handAnimation3 = hand3.GetComponent<Animation>();
                handAnimation3.wrapMode = WrapMode.Once;

                var t3 = hand3.transform.position;
                hand3.transform.position = new Vector3(t3.x - _size.x * (_tr % 6) + _size.x * _tr, t3.y,
                    t3.z + _size.z * (_tr / 6));
                var v3 = new Vector3(0.153f - _size.x * (_tr % 6), 0.113f, 0.339f + _size.z * (_tr / 6));
                ++_tr;

                yield return Bar("Prefabs/" + card.ToString(), v3,
                    Quaternion.Euler(new Vector3(-0.052f, 179.858f, 177.683f)), 1.0f);

                yield return new WaitForSeconds(handAnimation3.clip.length);
                Destroy(hand3);
                break;
            case Direction.Left:
                var hand2 = Instantiate(_hand, new Vector3(0.05f, 0.036f, 0.225f),
                    Quaternion.Euler(new Vector3(0f, 90.0f, 0f)));

                var handAnimation2 = hand2.GetComponent<Animation>();
                handAnimation2.wrapMode = WrapMode.Once;

                var t2 = hand2.transform.position;
                hand2.transform.position = new Vector3(t2.x - _size.x * (_lr / 6) + _size.x * _lr, t2.y,
                    t2.z - _size.z * (_lr % 6));
                var v2 = new Vector3(-0.087f - _size.x * (_lr / 6), 0.1117f, -0.0258f - _size.z * (_lr % 6));
                ++_lr;

                yield return Bar("Prefabs/" + card.ToString(), v2,
                    Quaternion.Euler(new Vector3(-0.052f, 89.858f, 177.683f)), 1.0f);

                yield return new WaitForSeconds(handAnimation2.clip.length);
                Destroy(hand2);
                break;
            case Direction.Right:
                var hand4 = Instantiate(_hand, new Vector3(0.048f, 0.036f, 0.071f),
                    Quaternion.Euler(new Vector3(0f, 270.0f, 0f)));

                var handAnimation4 = hand4.GetComponent<Animation>();
                handAnimation4.wrapMode = WrapMode.Once;

                var t4 = hand4.transform.position;
                hand4.transform.position = new Vector3(t4.x + _size.x * (_rr / 6), t4.y, t4.z + _size.z * (_rr % 6));
                var v4 = new Vector3(0.215f + _size.x * (_rr / 6), 0.115f, 0.078f + _size.z * (_rr % 6));
                ++_rr;

                yield return Bar("Prefabs/" + card.ToString(), v4,
                    Quaternion.Euler(new Vector3(-0.052f, 269.858f, 177.683f)), 1.0f);

                yield return new WaitForSeconds(handAnimation4.clip.length);
                Destroy(hand4);
                break;
            default:
                throw new ArgumentOutOfRangeException("direction", direction, null);
        }
    }

    private static IEnumerator Bar(string path, Vector3 vector3, Quaternion quaternion, float dt)
    {
        var card = Instantiate(Resources.Load(path), vector3, quaternion) as GameObject;
        if (card != null) card.SetActive(false);

        yield return new WaitForSeconds(dt);
        if (card != null) card.SetActive(true);
    }

    private void ShowHands()
    {
        for (var i = 0; i < 13; ++i)
        {
            var card = Instantiate(_handsLeft);
            if (_size == Vector3.zero)
            {
                _size = GetObjectSize(card);
            }

            var startPosition = _handsLeft.transform.position;
            card.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z - i * _size.x);
        }

        for (var i = 0; i < 13; ++i)
        {
            var card = Instantiate(_handsTop);
            if (_size == Vector3.zero)
            {
                _size = GetObjectSize(card);
            }

            var startPosition = _handsTop.transform.position;
            card.transform.position = new Vector3(startPosition.x - i * _size.x, startPosition.y, startPosition.z);
        }

        for (var i = 0; i < 13; ++i)
        {
            var card = Instantiate(_handsRight);
            if (_size == Vector3.zero)
            {
                _size = GetObjectSize(card);
            }

            var startPosition = _handsRight.transform.position;
            card.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + i * _size.x);
        }
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        foreach (var card in _riverCard)
        {
            if (byte.Parse(card.name) > _total)
            {
                card.SetActive(false);
            }
        }
    }
}