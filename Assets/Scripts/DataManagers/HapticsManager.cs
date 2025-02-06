using UnityEngine;
using Util;

namespace DataManagers
{
    public class HapticsManager : MonoBehaviour
    {
        private void Awake()
        {
            GameEvents.OnJigsawPiecePlacementSuccess += i => PlayHaptics();
            GameEvents.OnJigsawPiecePlacementFailed += PlayHaptics;
        }

        private void OnDestroy()
        {
            GameEvents.OnJigsawPiecePlacementSuccess -= i => PlayHaptics();
            GameEvents.OnJigsawPiecePlacementFailed -= PlayHaptics;
        }

        private void PlayHaptics()
        {
            Handheld.Vibrate();
        }
    
    }
}
