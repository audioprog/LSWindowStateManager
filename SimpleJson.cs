using Newtonsoft.Json;

using System.IO;
using System.Text;


namespace LSWindowStateManager
{
    public static class SimpleJson
    {
        public static string GetUserFolder() => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        public static T? LoadJsonToObject<T>(string relativePathFileInUserPath) where T : new()
        {
            T? toReturn = default;
            string mainSettingsFile = Path.Combine(GetUserFolder(), relativePathFileInUserPath);
            if (File.Exists(mainSettingsFile))
            {
                string json;
                using (var reader = new StreamReader(mainSettingsFile, Encoding.UTF8))
                {
                    json = reader.ReadToEnd();
                }
                toReturn = JsonConvert.DeserializeObject<T>(json);
            }

            toReturn ??= new T();
            return toReturn;
        }


        public static void SaveJson<T>(T toSave, string fileName) where T : new()
        {
            string json = JsonConvert.SerializeObject(toSave, Formatting.Indented);
            string fullFileName = Path.Combine(GetUserFolder(), fileName);
            File.WriteAllText(fullFileName, json, Encoding.UTF8);
        }
    }
}
