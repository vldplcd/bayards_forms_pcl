using System;
using System.Collections.Generic;
using System.Text;
using BayardsSafetyApp.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BayardsSafetyApp.DTO;

namespace BayardsSafetyApp
{
    //TODO: ОБЪЕДИНИТЬ В ОДИН МЕТОД ЗАПРОС
    public class API
    {

        const string UriSectionsListTemplate = "https://bayardssb-php.000webhostapp.com/api/allSections?lang={0}";
        const string UriSectionContent = "https://bayardssb-php.000webhostapp.com/api/section?sectionid={0}&&lang={1}";
        const string UriRiskContent = "https://bayardssb-php.000webhostapp.com/api/?riskid={0}&&lang={1}";

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
            using (HttpClient hc = new HttpClient())
            {
                var responseMsg = await hc.GetAsync(requestUri);
                var resultStr = await responseMsg.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ShellRequest<Section>>(resultStr).Data;
            }
            return result;
        }
        /// <summary>
        /// Method that gets the list of all risks and subsections from specified section by id and language
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns> 
        public async Task<List<SafetyObject>> getSectionContent(string Id, string language)
        {
            List<SafetyObject> result;
            string requestUri = String.Format(UriSectionContent, Id, language);
            using (HttpClient hc = new HttpClient())
            {
                var responseMsg = await hc.GetAsync(requestUri);
                var resultStr = await responseMsg.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ShellRequest<SafetyObject>>(resultStr).Data;
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
                var responseMsg = await hc.GetAsync(requestUri);
                var resultStr = await responseMsg.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ShellRequest<Risk>>(resultStr).Data[0];
            }
            return result;
        }
    }
}
