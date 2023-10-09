using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Snake : Animal
    {
        public Snake(string name, byte age):base(name, age) { }

		private bool _ispoisonous;

		public bool IsPoisonous
		{
			get { return _ispoisonous; }
			set 
			{
				if (value) Console.WriteLine("Poisonous snakes not taken by our company!");
				else
				{
					_ispoisonous = value;
                    Console.WriteLine("It can be taken by our company.");
                }
            }
		}

	}
}
