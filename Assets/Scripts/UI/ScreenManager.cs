using System;
using UnityEngine;
using Util;

namespace UI
{
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

        private void ShowScreenPostReadOperationComplete()
        {
            var screen = Instantiate(jigsawGameboardScreen, canvasTransform);
            screen.GetComponent<JigsawGameboardScreen>().Initialize();
        }
        
    }
}
