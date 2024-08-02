using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{

    [Range(0f, 30f)]
    public float scrollSpeed = 2f;

    [SerializeField]
    [Min(1)]
    int _maxClones = 15;

    float _textPreferredWidth;
    readonly LinkedList<RectTransform> _textTransforms = new();

    // Start is called before the first frame update
    void Awake()
    {
        _textTransforms.AddFirst((RectTransform)transform.GetChild(0));
        _textPreferredWidth = 170f;

        CreateClones();
    }

    void AttachTransformAtTheEnd(RectTransform rectTransform){
        float lastTransPosX = _textTransforms.Last.Value.localPosition.x;

        Vector3 newPos = rectTransform.localPosition;
        newPos.x = lastTransPosX + _textPreferredWidth;

        rectTransform.localPosition = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTransforms();
    }

    void MoveTransforms(){
        float distance = scrollSpeed * 30 * Time.deltaTime;

        foreach(RectTransform transform in _textTransforms)
        {
            Vector3 newPos = transform.localPosition;
            newPos.x -= distance;
            transform.localPosition = newPos;
        }

        CheckIfLeftMostTransformLeftMask();
    }

    void CheckIfLeftMostTransformLeftMask()
    {
        RectTransform rectTransform = _textTransforms.First.Value;

        if(rectTransform.localPosition.x + _textPreferredWidth <= 0)
            ReattachFirstTransformAtTheEnd();
    }

    void ReattachFirstTransformAtTheEnd()
    {
        float lastTransPosX = _textTransforms.Last.Value.localPosition.x;

        LinkedListNode<RectTransform> node = _textTransforms.First;

        Vector3 newPos = node.Value.localPosition;
        newPos.x = lastTransPosX + _textPreferredWidth;
        node.Value.localPosition = newPos;

        _textTransforms.RemoveFirst();
        _textTransforms.AddLast(node);
    }

    void CreateClones()
    {
        int clones = CalculateNecessaryClones();

        for(int i = 1; i<=clones; i++){
            RectTransform cloneTransform = Instantiate(_textTransforms.First.Value, transform);
            AttachTransformAtTheEnd(cloneTransform);
            _textTransforms.AddLast(cloneTransform);
        }
    }

    int CalculateNecessaryClones()
    {
        int clones = 0;
        RectTransform maskTransform = GetComponent<RectTransform>();

        do{
            clones++;

            if(clones == _maxClones)
            {
                break;
            }
        }
        while(maskTransform.rect.width / (_textPreferredWidth*clones)>=1);

        return clones;
    }
}
