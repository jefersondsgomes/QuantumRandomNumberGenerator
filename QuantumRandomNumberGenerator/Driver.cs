using System;
using System.Linq;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QuantumRandomNumberGenerator
{
    class Driver
    {
        private const int _maxRange = 1000;

        static void Main(string[] args)
        {
            using (var simulator = new QuantumSimulator())
            {
                // Inicializando variáveis.
                int output = _maxRange + 1;
                string bitString = "0";
                int size = Convert.ToInt32(
                    Math.Floor(
                        Math.Log(_maxRange, 2.0) + 1));

                while (output > _maxRange)
                {
                    // Resetando o valor se falhar.
                    bitString = "0";

                    // Executando a função quântica e atibuindo o resultado ao bitString.
                    bitString = String.Join(
                        "",
                        Enumerable.Range(0, size).Select(
                            x => RandomNumberGenerator
                            .Run(simulator).Result == Result.One ? "1" : "0"));

                    // Convertento o valor retornado pelo uso da função para inteiro.
                    int value = Convert.ToInt32(bitString, 2);
                    output = value;
                }

                // Mensagem com o número randomico gerado.
                Console.WriteLine($"\nThe random number generated is {output}.\n");
            }
        }
    }
}