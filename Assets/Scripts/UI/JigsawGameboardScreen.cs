using System.Collections.Generic;
using DataManagers;
using UnityEngine;
using Util;

namespace UI
{
    /// <summary>
    /// Main script that is attached to the jigsaw gameboard.
    /// </summary>
    public class JigsawGameboardScreen : MonoBehaviour
    {
        #region GAMEOBJECT_REFERENCES

        [SerializeField] private GameObject draggableJigsawPiece;
        [SerializeField] private JigsawPieceUiData[] piecesUiData;
        [SerializeField] private GameObject replaySection;

        #endregion
        /*-------------------------------------------------------------------------*/

        #region PRIVATE_VARIABLES

        private List<DraggableJigsawPiece> _draggableJigsawPiecesList;

        #endregion
        /*-------------------------------------------------------------------------*/

        private void Awake()
        {
            GameEvents.OnLevelComplete += CheckAndShowReplaySection;
        }

        private void OnDestroy()
        {
            GameEvents.OnLevelComplete -= CheckAndShowReplaySection;
        }

        public void Initialize()
        {
            var levelData = JigsawManager.Instance.GetJigsawCurrentLevelData();

            bool toBeInstantiated = false;
            if (_draggableJigsawPiecesList == null) {
                _draggableJigsawPiecesList = new List<DraggableJigsawPiece>();
                toBeInstantiated = true;
            }
            
            for (var index = 0; index < levelData.PiecesData.Count; index++)
            {
                var pieceData = levelData.PiecesData[index];
                if (toBeInstantiated) {
                    var jigsawPiece = Instantiate(draggableJigsawPiece, transform).GetComponent<DraggableJigsawPiece>();
                    _draggableJigsawPiecesList.Add(jigsawPiece);
                }
                _draggableJigsawPiecesList[index].Initialize(piecesUiData[index], pieceData.IsPlacedSuccessfully, pieceData.ID);
            }

            CheckAndShowReplaySection();
        }

        private void CheckAndShowReplaySection()
        {
            if (JigsawManager.Instance.IsCurrentLevelComplete()) {
                replaySection.SetActive(true);
            }
        }

        public void ReplayButtonClicked()
        {
            SoundManager.Instance.PlayPickSound();
            JigsawManager.Instance.ResetCurrentLevel();
            replaySection.SetActive(false);
            Initialize();
        }
        
    }
}
