using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Data
{
    public interface IUnityOfWork
    {
        void Commit();
    }
}
