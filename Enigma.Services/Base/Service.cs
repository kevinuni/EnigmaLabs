using Enigma.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Services.Base;

public class Service<TDocument> : IService<TDocument> //where TDocument : IDocument
{
    private IRepository<TDocument> _repository;

    public Service(IRepository<TDocument> repository)
    {
        this._repository = repository;
    }
}