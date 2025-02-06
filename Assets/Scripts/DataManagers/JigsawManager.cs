using System;
using System.Collections.Generic;
using Data;
using Newtonsoft.Json;
using UnityEngine;
using Util;

namespace DataManagers
{
    public class JigsawManager
    {

        #region SINGELTON

        private static JigsawManager _instance;
        public static JigsawManager Instance
        {
            get {
                if (_instance == null) {
                    _instance = new JigsawManager();
                }
                return _instance;
            }
        }
        #endregion
        /*-------------------------------------------------------------------------*/

        #region PRIVATE_VARIABLES

        private Dictionary<int, JigsawLevelData> _jigsawLevelData; // Dictionary that maintains the data for different levels of the jigsaw game.

        #endregion
        /*-------------------------------------------------------------------------*/
        
        #region GETTERS
        
        public Dictionary<int, JigsawLevelData> JigsawLevelData => _jigsawLevelData; 
        
        #endregion 
        /*-------------------------------------------------------------------------*/

        #region CONSTRUCTOR

        private JigsawManager()
        {
            _jigsawLevelData = new Dictionary<int, JigsawLevelData>();
            GameEvents.OnJigsawPiecePlacementSuccess += OnJigsawPiecePlacementSuccess;
        }

        ~JigsawManager()
        {
            GameEvents.OnJigsawPiecePlacementSuccess -= OnJigsawPiecePlacementSuccess;
        }

        #endregion
        /*-------------------------------------------------------------------------*/

        private void OnJigsawPiecePlacementSuccess(int id)
        {
            int currentLevelNo = GetCurrentJigsawLevel();
            if (_jigsawLevelData.ContainsKey(currentLevelNo)) {
                _jigsawLevelData[currentLevelNo].UpdatePiecePlacedSuccessfully(id);
                _jigsawLevelData[currentLevelNo].CheckAndUpdateLevelComplete();
            }
            SaveDataToLocalFile();
        }
        
        public void SaveDataToLocalFile()
        {
            string json = JsonConvert.SerializeObject(_instance);
            GameManager.Instance.SaveDataToLocalFiles(json);
        }

        public void ReloadDataFromLocalFile(string dataString)
        {
            try
            {
                JsonConvert.PopulateObject(dataString, _instance);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error in reloading data from local file: Error encountered is {e.Message} and data string is: {dataString}");
                _jigsawLevelData = new Dictionary<int, JigsawLevelData>();
            }
            
        }

        public int GetCurrentJigsawLevel()
        {
            return 1; // hardcoded this to 1 since only 1 level is there as of now.
        }

        public JigsawLevelData GetJigsawCurrentLevelData()
        {
            int currentLevel = GetCurrentJigsawLevel(); 
            if (!_jigsawLevelData.ContainsKey(currentLevel)) {
                var levelData = new JigsawLevelData();
                levelData.PiecesData = new List<JigsawPieceLocalData>();
                for (int i = 0; i < 9; i++) {
                    levelData.PiecesData.Add(new JigsawPieceLocalData(i));
                }
                _jigsawLevelData.Add(currentLevel, levelData);
            }
            return _jigsawLevelData[currentLevel];
        }

        public bool IsCurrentLevelComplete()
        {
            int currentLevel = GetCurrentJigsawLevel();
            return _jigsawLevelData.ContainsKey(currentLevel) && _jigsawLevelData[currentLevel].IsLevelComplete;
        }

        public void ResetCurrentLevel()
        {
            int currentLevel = GetCurrentJigsawLevel();
            if (_jigsawLevelData.ContainsKey(currentLevel)) {
                _jigsawLevelData.Remove(currentLevel);
            }
            GetJigsawCurrentLevelData();
            SaveDataToLocalFile();
        }
        
    }
}
