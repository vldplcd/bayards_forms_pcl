using System.Collections.Generic;

namespace BayardsSafetyApp.DTO
{
    public class ShellRequest<T>
    {
        /// <summary>
        /// Data list -- is a list of specified type, SafetyObject/SectionRisk/etc
        /// </summary>
        public List<T> Data { get; set; }
    }
}
