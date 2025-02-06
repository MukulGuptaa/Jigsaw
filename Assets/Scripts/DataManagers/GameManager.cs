using System.IO;
using UnityEngine;
using Util;

namespace DataManagers
{
    /// <summary>
    /// Game manager class responsible for initial read operation from the local file and also saves the data in local files.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region SINGELTON

        private static GameManager _instance;
        public static GameManager Instance => _instance;

        #endregion
        /*-------------------------------------------------------------------------*/

        #region PRIVATE_VARIABLES

        private string _filesSaveLocation;

        #endregion
        /*-------------------------------------------------------------------------*/
        
        
        private void Awake()
        {
            _instance = this;
            _filesSaveLocation = Application.persistentDataPath + "/jigsawData.json";
            LoadDataFromLocalFiles();
        }

        private void LoadDataFromLocalFiles()
        {
            if (!File.Exists(_filesSaveLocation)) {
                GameEvents.RaiseOnFileReadComplete();
                return;
            }
            string jsonString = File.ReadAllText(_filesSaveLocation);
            JigsawManager.Instance.ReloadDataFromLocalFile(jsonString);
            GameEvents.RaiseOnFileReadComplete();
        }

        public void SaveDataToLocalFiles(string jsonString)
        {
            File.WriteAllText(_filesSaveLocation, jsonString);
        }
        
    }
}
