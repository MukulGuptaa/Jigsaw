using System;

namespace DataManagers
{
    public class JigsawPieceLocalData
    {
        public int id;
        public bool isPlacedSuccessfully;

        public JigsawPieceLocalData(int id)
        {
            this.id = id;
        }

        public void SetPiecePlacedSuccessfully()
        {
            isPlacedSuccessfully = true;
        }
        
    }
}