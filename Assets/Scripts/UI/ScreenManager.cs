using System;
using UnityEngine;
using Util;

namespace UI
{
    /// <summary>
    /// ScreenManager class that manages the screen to be shown next.
    /// </summary>
    public class ScreenManager : MonoBehaviour
    {
        #region GAMEOBJECT_REFERENCES

        [SerializeField] private Transform canvasTransform;
        [SerializeField] private GameObject jigsawGameboardScreen;

        #endregion
        /*-------------------------------------------------------------------------*/


        private void Awake()
        {
            GameEvents.OnFileReadComplete += ShowScreenPostReadOperationComplete;
        }

        private void OnDestroy()
        {
            GameEvents.OnFileReadComplete -= ShowScreenPostReadOperationComplete;
        }

        /// <summary>
        /// Called post the initial read operation from local files is complete.
        /// </summary>
        private void ShowScreenPostReadOperationComplete()
        {
            var screen = Instantiate(jigsawGameboardScreen, canvasTransform);
            screen.GetComponent<JigsawGameboardScreen>().Initialize();
        }
        
    }
}
