using System;

namespace BayardsSafetyApp
{
    public class DataBaseUOW : IDisposable
    {
        private const string RiskDataBaseName = "bayards_risks.db";
        private static DbRepository _riskRepository;
        public DbRepository RiskDatabase => _riskRepository ?? (_riskRepository = new DbRepository(RiskDataBaseName));

        private const string SectionDataBaseName = "bayards_sections.db";
        private static DbRepository _sectionRepository;
        public DbRepository SectionDatabase => _sectionRepository ?? (_sectionRepository = new DbRepository(SectionDataBaseName));

        private const string MediaDataBaseName = "bayards_media.db";
        private static DbRepository _mediaRepository;
        public DbRepository MediaDatabase => _mediaRepository ?? (_mediaRepository = new DbRepository(MediaDataBaseName));

        public DataBaseUOW()
        {          
        }

        #region DisposeRegion
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _riskRepository.Dispose();
                    _sectionRepository.Dispose();
                    _mediaRepository.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}