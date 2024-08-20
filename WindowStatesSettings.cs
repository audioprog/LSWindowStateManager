using Newtonsoft.Json;


namespace LSWindowStateManager
{
    [Serializable]
    public class WindowStatesSettings : ObservableObject
    {
        public WindowStatesSettings()
        {
        }


        public WindowStateSettings LocalWindowState { get; set; } = new WindowStateSettings();


        public WindowStateSettings RemoteWindowState { get; set; } = new WindowStateSettings();


        [JsonIgnore]
        public string MainSettingsFileName { get; set; } = string.Empty;


        public void Save()
        {
            SimpleJson.SaveJson(this, MainSettingsFileName);
        }
    }
}
