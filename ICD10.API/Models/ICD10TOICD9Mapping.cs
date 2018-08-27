﻿using System;
namespace ICD10.API.Models
{
    public class ICD10TOICD9Mapping : ICDBaseModel
    {
        public string ICD9Code { get; set; }
        public string ICD10Code { get; set; }
        public string Flags { get; set; }
    }
}
