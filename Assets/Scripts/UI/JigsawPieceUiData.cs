using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class JigsawPieceUiData
    {
        [SerializeField] public RectTransform initialPos;
        [SerializeField] public RectTransform finalPos;
        [SerializeField] public Sprite sourceImage;
        [NonSerialized] public bool isPlacedSuccessfully;
        [NonSerialized] public int id;
    }
}
