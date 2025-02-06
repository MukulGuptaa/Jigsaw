
namespace Data
{
    /// <summary>
    /// Class that keeps data for individual jigsaw pieces.
    /// </summary>
    public class JigsawPieceLocalData
    {
        public int ID;
        public bool IsPlacedSuccessfully;

        public JigsawPieceLocalData(int id)
        {
            this.ID = id;
        }

        public void SetPiecePlacedSuccessfully()
        {
            IsPlacedSuccessfully = true;
        }
        
    }
}