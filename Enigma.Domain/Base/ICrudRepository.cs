﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Base;

public interface ICrudRepository<TDocument> where TDocument : IDocument
{
    Task<IEnumerable<TDocument>> Select(IDbTransaction tx = null);

    Task<TDocument> Select(int? PersonId, IDbTransaction tx = null);

    Task<TDocument> Insert(TDocument person, IDbTransaction tx = null);

    Task<TDocument> Update(int id, TDocument person, IDbTransaction tx = null);

    Task<int> Delete(int? id, IDbTransaction tx = null);
}