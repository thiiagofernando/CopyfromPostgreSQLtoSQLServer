﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CopyData.Models.SqlServer
{
    public class Contato
    {
        public int Id { get; set; }
        public int codPostgre { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
