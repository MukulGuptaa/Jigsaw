using System;

namespace Util
{
    public class GameEvents
    {
        public static Action OnFileReadComplete;
        public static void RaiseOnFileReadComplete()
        {
            OnFileReadComplete?.Invoke();
        }

        public static Action OnJigsawPiecePicked;
        public static void RaiseOnJigsawPiecePicked()
        {
            OnJigsawPiecePicked?.Invoke();
        }
        
        public static Action<int> OnJigsawPiecePlacementSuccess;
        public static void RaiseOnJigsawPiecePlacementSuccess(int id)
        {
            OnJigsawPiecePlacementSuccess?.Invoke(id);
        }
        
        public static Action OnJigsawPiecePlacementFailed;
        public static void RaiseOnJigsawPiecePlacementFailed()
        {
            OnJigsawPiecePlacementFailed?.Invoke();
        }

        public static Action OnLevelComplete;
        public static void RaiseOnLevelComplete()
        {
            OnLevelComplete?.Invoke();
        }

    }
}
