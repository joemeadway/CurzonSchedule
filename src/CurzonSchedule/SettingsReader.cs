using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

namespace CurzonSchedule
{
    public class SettingsReader
    {
        public string[] GetCinemas()
        {
            Settings settings;
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            if (isoStore.FileExists("curzonsettings.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("curzonsettings.json", FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        settings = (Settings)serializer.Deserialize(reader, typeof(Settings));
                    }
                }
            }
            else
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("curzonsettings.json", FileMode.CreateNew, isoStore))
                {
                    settings = new Settings();
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, settings);
                    }
                }
            }
            return settings.CinemasToFetch;
        }
    }
}
