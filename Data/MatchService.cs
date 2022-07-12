using System.Runtime.Serialization.Json;
using System.Text;

namespace Tiwaz.WebClient.Data
{
    public class MatchService
    {
        private static readonly string _ServerBaseUrl = "https://localhost:7077/";

        /// <summary>
        /// Gets all Matches from the Server
        /// </summary>
        /// <returns></returns>
        public async Task<List<Match>> GetMatchesAsync()
        {
            var matchList = new List<Match>();
            HttpClient client = new HttpClient();

            try
            {
                using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "match"))
                {
                    var sR = new StreamReader(jsonStream);
                    var json = await sR.ReadToEndAsync();
                    sR.Close();

                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                    {
                        DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(List<Match>));
                        matchList = (List<Match>)ds.ReadObject(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get match list. Error: {0}", ex.ToString());
                //{ "Type 'Tiwaz.WebClient.Match' cannot be serialized. Consider marking it with the DataContractAttribute
                //attribute, and marking all of its members you want serialized with the DataMemberAttribute attribute.
                //Alternatively, you can ensure that the type is public and has a parameterless constructor - all public
                //members of the type will then be serialized, and no attributes will be required."}
            }

            return matchList;
        }
    }
}
