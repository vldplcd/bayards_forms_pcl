using System;
using System.Collections.Generic;
using BayardsSafetyApp.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BayardsSafetyApp
{
    //TODO: ОБЪЕДИНИТЬ В ОДИН МЕТОД ЗАПРОС
    public class API
    {

        const string UriSectionsListTemplate = "https://bayardssb-php.000webhostapp.com/api/allSections?lang={0}";
        const string UriSectionContent = "https://bayardssb-php.000webhostapp.com/api/section?sectionid={0}&&lang={1}";
        const string UriRiskContent = "https://bayardssb-php.000webhostapp.com/api/risk?riskid={0}&lang={1}";

        //TODO: 
        //Добавить поисковые запросы в функционал API

        /// <summary>
        /// Method that gets the complete list of sections; language is specified with language variable
        /// </summary>
        /// <returns>List of sections</returns>
        public async Task<List<Section>> getCompleteSectionsList(string language)
        {
            string requestUri = String.Format(UriSectionsListTemplate, language);
            List<Section> result;
            try
            {
                using (HttpClient hc = new HttpClient() { Timeout = new TimeSpan(0,0,30)})
                {
                    var responseMsg = hc.GetAsync(requestUri).Result;
                    var resultStr = responseMsg.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeAnonymousType(resultStr, new { Sections = new List<Section>() });
                    //result = JsonConvert.DeserializeObject<ShellRequest<Section>>(resultStr).Data;
                    result = res.Sections;
                    if (result.Count == 0 || result[0].Id_s == null)
                        throw new Exception("No info downloaded.");
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Method that gets the list of all risks and subsections from specified section by id and language
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns> 
        public async Task<SectionContents> getSectionContent(string Id, string language)
        {
            SectionContents result;
            string requestUri = String.Format(UriSectionContent, Id, language);
            using (HttpClient hc = new HttpClient())
            {
                var responseMsg = hc.GetAsync(requestUri).Result;
                var resultStr = responseMsg.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<SectionContents>(resultStr);
                if (result.Section == null)
                    throw new Exception("No info downloaded. Trying to retry");
            }
            return result;
        }


        /// <summary>
        /// Method that sends password to the server
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Returns true if password is correct, else returns false</returns>
        public bool isPasswordCorrect(string password)
        {
            if (password == "central") return true; //УДАЛИТЬ ПОСКОРЕЕЕЕЕ
            using (HttpClient hc = new HttpClient())
            {
                //POST REQUEST
            }
            return false;

        }
        /// <summary>
        /// Method that gets all data to the specified risk by id and lang
        /// </summary>
        /// <param name="risk"></param>
        /// <returns>List of all links with risk data</returns>
        public async Task<Risk> getRiskContent(string Id, string language)
        {
            Risk result;
            string requestUri = string.Format(UriRiskContent, Id, language);
            using (HttpClient hc = new HttpClient())
            {
                var responseMsg = hc.GetAsync(requestUri).Result;
                var resultStr = responseMsg.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeAnonymousType(resultStr, new { Risk = new Risk(), Media = new List<string>() });
                res.Risk.Media = res.Media;
                result = res.Risk;
                if (result.Id_r == null)
                    throw new Exception("No info downloaded. Trying to retry");
            }
            return result;
        }
    }
}
