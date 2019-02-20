using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace iconic.common.CorporateBuzzWords
{    
    [DataContract]
    public class CorporateBuzzWordResponse
    {
        [DataMember(Name="phrase")]
        public string Phrase { get; set; }        
    }

    public class BuzzWordGenerator
    {
        public async Task<string> GenerateRandomBuzz()
        {
            CorporateBuzzWordResponse randomBuzzResponse = null;
            
            using (HttpClient _client = new HttpClient())
            {
                var randomBuzzStream = _client.GetStreamAsync("https://corporatebs-generator.sameerkumar.website");

                randomBuzzResponse = new DataContractJsonSerializer(typeof(CorporateBuzzWordResponse)).ReadObject(await randomBuzzStream) as CorporateBuzzWordResponse;
            }
            return randomBuzzResponse?.Phrase;
        }
    }

}