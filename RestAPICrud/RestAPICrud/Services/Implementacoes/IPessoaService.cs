using RestAPICrud.Models;
using System.Collections.Generic;

namespace RestAPICrud.Services.Implementacoes
{
    public interface IPessoaService
    {
        Pessoa FindById(long id);

        List<Pessoa> FindAll();

        Pessoa Create(Pessoa pessoa);

        Pessoa Update(Pessoa pessoa);

        Pessoa Delete(long id);
    }
}
