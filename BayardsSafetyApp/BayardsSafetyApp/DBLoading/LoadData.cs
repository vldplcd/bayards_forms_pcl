using BayardsSafetyApp.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BayardsSafetyApp.DBLoading
{
    public class LoadData
    {
        private API _api = new API();
        public double Process { get; set; }
        List<Risk> _risks;
        List<Section> _sections;
        List<Media> _mediaList;
        string[] _langs = new string[] { "eng", "nl" };
        string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath("bayards.db");

        private async void UploadSections(List<Section> sects)
        {

            using (var context = new SQLiteConnection(databasePath))
            {
                context.CreateTable<Section>();
                context.CreateTable<Risk>();
                context.CreateTable<Media>();
                try
                {
                    if (sects.Count != 0)
                        context.InsertAll(sects, typeof(Section));
                    if (_risks.Count != 0)
                        context.InsertAll(_risks, typeof(Risk));
                    if (_mediaList.Count != 0)
                        context.InsertAll(_mediaList, typeof(Media));
                }
                catch(Exception ex)
                {

                }
                
            } 
            //App.Database.CreateTable<Section>().Wait();
            //App.Database.InsertItemsAsync(sects).Wait();
            //Application.Current.Properties["AllSections"] = _sections;
        }
        public async Task ToDatabase()
        {
            Process = 0;
            _risks = new List<Risk>();
            _sections = new List<Section>();
            _mediaList = new List<Media>();
            var sectIds = new List<string>();
            foreach (var lang in _langs)
            {
                var temp_s = await _api.getCompleteSectionsList(lang);
                if (temp_s.Count != 0)
                {
                    foreach (var s in temp_s)
                    {
                        if (lang == "eng")
                            sectIds.Add(s.Id_s);
                        s.Lang = lang;
                        s.Parent_s = "null";
                    }
                    _sections.AddRange(temp_s);
                }
            }
            Process = 0.1;
            if (sectIds.Count > 0)
            {
                var n = sectIds.Count;
                foreach (var sId in sectIds)
                {
                    AllSectionContent(sId).Wait();
                    Process += 1/(n + 5);
                }
                    
            }
            Process = 1;

            UploadSections(_sections);
        }

        private async Task AllSectionContent(string sectId)
        {
            var temp_sc = await _api.getSectionContent(sectId, "eng");
            var sectIds = new List<string>();
            var temp_risks = new List<Risk>();
            var temp_risk = new Risk();
            var temp_mediaList = new List<Media>();
            foreach (var r in temp_sc.Risks)
            {
                foreach (var lang in _langs)
                {
                    temp_risk = new Risk();
                    temp_risk = await GetRisk(r.Id_r, lang, sectId);
                    if (temp_risk != null)
                    {
                        temp_risks.Add(temp_risk);
                        foreach (var url in temp_risk.Media)
                            temp_mediaList.Add(new Media { Lang = lang, Url = url, Id_r = r.Id_r });
                    }
                        
                }
            }
            _risks.AddRange(temp_risks);

            foreach (var lang in _langs)
            {
                var temp_subs = (await _api.getSectionContent(sectId, lang)).Subsections;
                if (temp_subs.Count != 0)
                {
                    foreach (var s in temp_subs)
                    {
                        if (lang == "eng")
                            sectIds.Add(s.Id_s);
                        s.Lang = lang;
                        s.Parent_s = sectId;
                    }
                    _sections.AddRange(temp_subs);
                }
            }
            if(sectIds.Count > 0)
            {
                foreach (var sId in sectIds)
                    AllSectionContent(sId).Wait();
            }


        }

        private async Task<Risk> GetRisk(string rId, string lang, string sectId)
        {
            
            var temp_risk = await _api.getRiskContent(rId, lang);
            if (temp_risk != null)
            {
                temp_risk.Lang = lang;
                temp_risk.Parent_s = sectId;
            }
            return temp_risk;
        }
    }
}
