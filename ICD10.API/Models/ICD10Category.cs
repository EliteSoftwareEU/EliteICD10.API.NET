﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICD10.API.Models
{
    public class ICD10Category
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public ICollection<ICD10Code> ICD10Codes { get; set; }
    }
}