using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMuveletek
{
    public class Kifejezes
    {
        int operandusBal;
        string muvelet;
        int operandusJobb;

        public Kifejezes(int operandusBal, string muvelet, int operandusJobb)
        {
            this.operandusBal = operandusBal;
            this.muvelet = muvelet;
            this.operandusJobb = operandusJobb;
        }

        public int OperandusBal { get => operandusBal; }
        public string Muvelet { get => muvelet; }
        public int OperandusJobb { get => operandusJobb; }
    }
}
