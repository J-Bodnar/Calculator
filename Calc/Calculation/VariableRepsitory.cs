using Calc.Models;
using System.Collections.Generic;
using System.Linq;

namespace Calc.Calculation
{
    class VariableRepsitory
    {
        private Dictionary<string, double> variables;

        public VariableRepsitory()
        {
            variables = new Dictionary<string, double>();
        }

        public void Add(string name)
        {
            if (!variables.Keys.ToList().Contains(name))
            {
                variables.Add(name, 0);
            }
        }

        public void Add(Variable variable)
        {
            if (!variables.Keys.ToList().Contains(variable.Name))
            {
                variables.Add(variable.Name, variable.Value);
            }
            else
            {
                variables[variable.Name] = variable.Value;
            };
        }

        public double getValueByName(string name)
        {
            return variables[name];
        }
    }
}
 