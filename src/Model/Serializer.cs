using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactorioBlueprintHelper.Model.BlueprintObjects;
using Ionic.Zlib;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FactorioBlueprintHelper.Model
{
    public static class Serializer
    {
        public static BlueprintRoot Decode(string encodedString)
        {
            byte[] decompressedData = null;
            byte[] compressedData = Convert.FromBase64String(encodedString.Substring(1));

            using (var outputStream = new MemoryStream())
            using (var ms = new MemoryStream(compressedData))
            using (var ds = new ZlibStream(ms, CompressionMode.Decompress))
            {
                ds.CopyTo(outputStream);
                decompressedData = outputStream.ToArray();
            }

            string decodedString = Encoding.UTF8.GetString(decompressedData);

            var contractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
            var blueprint = JsonConvert.DeserializeObject<BlueprintRoot>(decodedString, new JsonSerializerSettings { ContractResolver = contractResolver });

            return blueprint;
        }

        public static string Encode(BlueprintRoot blueprint)
        {
            var contractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
            string json = JsonConvert.SerializeObject(blueprint,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = contractResolver,
                    Formatting = Formatting.None,
                    Converters = new List<JsonConverter> { new FloatJsonConverter() }
                });

            byte[] compressedData2 = null;
            byte[] data = Encoding.UTF8.GetBytes(json);

            using (var inputStream = new MemoryStream(data))
            using (var ms = new MemoryStream())
            {
                using (var ds = new ZlibStream(ms, CompressionMode.Compress))
                {
                    inputStream.CopyTo(ds);
                }

                compressedData2 = ms.ToArray();
            }

            string encodedString2 = Convert.ToBase64String(compressedData2);

            var sb = new StringBuilder("0");
            sb.Append(encodedString2);
            string result = sb.ToString();

            return result;
        }

        private class FloatJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(float);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue(((float)value).ToString("0.###", CultureInfo.InvariantCulture));
            }
        }
    }
}
