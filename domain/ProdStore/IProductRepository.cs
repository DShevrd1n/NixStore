﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore
{
    public interface IProductRepository
    {
        Product [] GetAllByName(string partname);
        Product[] GetAllByArticul(string articul);

    }
}