﻿using System;
using System.Collections.Generic;

namespace MagicCollection.API.Models
{
    public partial class CollectionUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
