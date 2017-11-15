using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public enum FormasPagamento
    {
        [Description("A vista - dinheiro")]
        A_VISTA_DINHEIRO = 0,
        [Description("A vista - débito")]
        A_VISTA_DEBITO = 1,
        [Description("Outros")]
        OUTROS = 2
    }
}
