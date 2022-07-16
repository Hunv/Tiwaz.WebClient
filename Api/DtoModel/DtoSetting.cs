using System;
using System.Collections.Generic;
using System.Text;

namespace Tiwaz.WebClient.Api.DtoModel
{
    public class DtoSetting
    {
        /// <summary>
        /// The name of the setting
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The value of the setting
        /// </summary>
        public string? Value { get; set; }
    }
}
