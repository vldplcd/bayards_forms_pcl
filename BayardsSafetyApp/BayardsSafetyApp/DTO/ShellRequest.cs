using BayardsSafetyApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
