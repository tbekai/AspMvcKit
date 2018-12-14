﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProject.Models
{
    abstract public class Model
    {
        public int Id { get; set; }

        abstract public void UpdateFrom(Model source);

    }
}