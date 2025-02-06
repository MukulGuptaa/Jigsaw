using System.Collections;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;

namespace UI
{
    public class DraggableJigsawPiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        #region GAMEOBJECT_REFERENCES

        [SerializeField] private Image sourceImage;
    
        #endregion
        /*-------------------------------------------------------------------------*/

        #region PRIVATE_VARIABLES

        private JigsawPieceUiData _uiData;
        private Vector2 _offset;
        private Canvas _canvas;

        #endregion
        /*-------------------------------------------------------------------------*/
    
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_uiData.isPlacedSuccessfully) {
                return;
            }

            _canvas = gameObject.AddComponent<Canvas>();
            _canvas.overrideSorting = true;
            _canvas.sortingOrder = 2;
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint
            );
            GameEvents.RaiseOnJigsawPiecePicked();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_uiData.isPlacedSuccessfully) {
                return;
            }
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint
            );
            (transform as RectTransform).anchoredPosition = localPoint;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_uiData.isPlacedSuccessfully) {
                return;
            }
            
            if(Vector2.Distance(transform.position, _uiData.finalPos.position) <= 30f) // Successfull piece placement
            {
                transform.position = _uiData.finalPos.position;
                _uiData.isPlacedSuccessfully = true;
                StartCoroutine(PlayShineEffect());
                GameEvents.RaiseOnJigsawPiecePlacementSuccess(_uiData.id);
            }
            else // Unsuccessfull piece placement, go back to initial position
            {
                transform.position = _uiData.initialPos.position;
                GameEvents.RaiseOnJigsawPiecePlacementFailed();
            }
            
            if (_canvas != null) {
                Destroy(_canvas);
            }
        }

        private IEnumerator PlayShineEffect()
        {
            var uiEffect = gameObject.AddComponent<UIEffect>();
            uiEffect.transitionFilter = TransitionFilter.Shiny;
            uiEffect.LoadPreset("Shiny");
            uiEffect.transitionRate = 0.5f;
            uiEffect.transitionWidth = 0.25f;
            uiEffect.transitionSoftness = 0.54f;
            uiEffect.transitionColor = Color.white;
            
            var tweener = gameObject.AddComponent<UIEffectTweener>();
            tweener.wrapMode = UIEffectTweener.WrapMode.Once;
            tweener.duration = 0.5f;
            
            UIEffectProjectSettings.shaderVariantCollection.WarmUp();
            yield return new WaitForSeconds(0.6f);
            Destroy(tweener);
            Destroy(uiEffect);
            
        }

        public void Initialize(JigsawPieceUiData uiData, bool isPlacedSuccessfully, int id)
        {
            _uiData = new JigsawPieceUiData
            {
                initialPos = uiData.initialPos,
                finalPos = uiData.finalPos,
                isPlacedSuccessfully = isPlacedSuccessfully,
                id =  id
            };
            sourceImage.sprite = uiData.sourceImage;
            sourceImage.SetNativeSize();
            transform.position = isPlacedSuccessfully ? uiData.finalPos.transform.position : uiData.initialPos.transform.position;
        }
    
    
    }
}
