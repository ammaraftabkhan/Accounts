using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public dynamic Id { get; }
        public EntityNotFoundException(string entityName, dynamic guId)
                  : base($"{entityName} with ID: {guId} not found.")
                      => Id = guId;
    }
}
