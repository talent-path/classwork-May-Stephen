﻿using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface IRequestRepo
    {
        Request AddRequest(Request toAdd, int id);
    }
}