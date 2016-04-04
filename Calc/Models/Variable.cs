

namespace Calc.Models
{
    class Variable
    {   
        public string Name { get; }
        public double Value { get; set; }


        /// <summary>
        /// Cunstractor initializating numeric member of the math expression,
        /// as a Variable with empty name.
        /// </summary>
        /// <param name="value">value ob the numeric member</param>
        public Variable(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Cunstractor initializating Variable having name and value.
        /// </summary>
        /// <param name="name">name of the Variable</param>
        /// <param name="value">value of the Variable</param>
        public Variable(string name, double value)
        {
            Name = name;
            Value = value;
        }

        
    }
}
