﻿using System;

namespace FantasyHockey.Web.Models
{
    public class BaseViewModel
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}