using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FaraBotModerator.Model;

namespace FaraBotModerator.Controller
{
    public static class SecretKeyController
    {
        private const string SecretFile = "secrets.json";
        public static SecretKeyModel LoadKeys()
        {
            SecretKeyModel secretKeys;
            using (var file = File.OpenText(SecretFile))
            {
                var jsonData = file.ReadToEnd();
                secretKeys = JsonSerializer.Deserialize<SecretKeyModel>(jsonData);
            }
            return secretKeys;
        }

        public static void SaveKeys(SecretKeyModel keys)
        {
            using (var writer = new StreamWriter(SecretFile))
            {
                var option = new JsonSerializerOptions {WriteIndented = true};
                var jsonData = JsonSerializer.Serialize(keys, option);
                writer.WriteLine(jsonData);
            }
        }
    }
}