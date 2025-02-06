using System;
using System.Collections.Generic;
using DataManagers;
using Util;

namespace Data
{
    public class JigsawLevelData
    {
        public List<JigsawPieceLocalData> PiecesData;
        public bool IsLevelComplete;

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
                if (!PiecesData[i].isPlacedSuccessfully) {
                    return;
                }
            }
            IsLevelComplete = true;
            GameEvents.RaiseOnLevelComplete();
        }
        
    }
}
