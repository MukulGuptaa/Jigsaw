using UnityEngine;
using Util;

public class SoundManager : MonoBehaviour
{
    #region REFERENCES

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip pickSound;
    [SerializeField] private AudioClip rightPlacementSound;
    [SerializeField] private AudioClip wrongPlacementSound;
    [SerializeField] private AudioClip levelCompleteSound;

    #endregion
    /*-------------------------------------------------------------------------*/

    #region SINGELTION

    private static SoundManager _instance;
    public static SoundManager Instance => _instance;

    #endregion
    /*-------------------------------------------------------------------------*/

    private void Awake()
    {
        _instance = this;
        GameEvents.OnJigsawPiecePlacementSuccess += i => PlayRightPlacementSound();
        GameEvents.OnJigsawPiecePlacementFailed += PlayWrongPlacementSound;
        GameEvents.OnJigsawPiecePicked += PlayPickSound;
        GameEvents.OnLevelComplete += PlayLevelCompleteSound;
    }

    private void OnDestroy()
    {
        GameEvents.OnJigsawPiecePlacementSuccess -= i => PlayRightPlacementSound();
        GameEvents.OnJigsawPiecePlacementFailed -= PlayWrongPlacementSound;
        GameEvents.OnJigsawPiecePicked -= PlayPickSound;
        GameEvents.OnLevelComplete -= PlayLevelCompleteSound;
    }

    public void PlayPickSound()
    {
        audioSource.PlayOneShot(pickSound);
    }

    private void PlayRightPlacementSound()
    {
        audioSource.PlayOneShot(rightPlacementSound);
    }

    private void PlayWrongPlacementSound()
    {
        audioSource.PlayOneShot(wrongPlacementSound);
    }

    private void PlayLevelCompleteSound()
    {
        audioSource.PlayOneShot(levelCompleteSound);
    }
    
}
