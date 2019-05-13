using CopyData.Context.PostgreSQL;
using CopyData.Context.SqlServer;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CopyData
{
    class Program
    {
        static PostegreContext _dbPostgre = new PostegreContext();
        static SqlServerContext _dbsqlserver = new SqlServerContext();
        static void Main(string[] args)
        {
            List<Models.PostgreSQL.Contato> listaContatosPostgre = new List<Models.PostgreSQL.Contato>();
            List<Models.SqlServer.Contato> listaContatosSqlserver = new List<Models.SqlServer.Contato>();

            listaContatosPostgre = _dbPostgre.contato.ToList();
            listaContatosSqlserver = _dbsqlserver.contatos.ToList();
            bool save = false;
            foreach (var item in listaContatosSqlserver)
            {
                foreach (var item2 in listaContatosPostgre)
                {
                    if (item.codPostgre == item2.Id)
                    {
                        if (item.Nome != item2.Nome)
                        {
                            item.Nome = item2.Nome;
                            save = true;
                        }

                        if (item.Email != item2.Email)
                        {
                            item.Email = item.Email;
                            save = true;
                        }

                        if (item.Telefone != item2.Telefone)
                        {
                            item.Telefone = item2.Telefone;
                            save = true;
                        }
                        if (save == true)
                        {
                            _dbsqlserver.SaveChanges();
                        }
                    }

                    if (item.codPostgre != item2.Id)
                    {
                        var existe = _dbsqlserver.contatos.Where(x => x.codPostgre == item2.Id).ToList();
                        if (existe.Count < 1)
                        {
                            var naoExiste = new Models.SqlServer.Contato
                            {
                                Nome = item2.Nome,
                                codPostgre = item2.Id,
                                Email = item2.Email,
                                Telefone = item2.Telefone
                            };
                            _dbsqlserver.contatos.Add(naoExiste);
                            _dbsqlserver.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
