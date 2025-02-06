using System.Collections.Generic;
using DataManagers;
using Util;

namespace Data
{
    /// <summary>
    /// This is the class that keeps the data related to a particular level of the game.
    /// </summary>
    public class JigsawLevelData
    {
        public List<JigsawPieceLocalData> PiecesData; // List of pieces data
        public bool IsLevelComplete; // bool flag to tell whether this level is completed

        public JigsawLevelData()
        {
            PiecesData = new List<JigsawPieceLocalData>();
            IsLevelComplete = false;
        }

        public void UpdatePiecePlacedSuccessfully(int id)
        {
            PiecesData[id].SetPiecePlacedSuccessfully();
        }

        public void CheckAndUpdateLevelComplete()
        {
            for (int i = 0; i < PiecesData.Count; i++) {
                if (!PiecesData[i].IsPlacedSuccessfully) {
                    return;
                }
            }
            IsLevelComplete = true;
            GameEvents.RaiseOnLevelComplete();
        }
        
    }
}
