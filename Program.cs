using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using test_desenvolvedorSP.Models;

namespace test_desenvolvedorSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* resposta 2 */
            Resposta2();
            /* reposta 3 e 4 */
            Resposta3e4();

            /*resposta 5 */
            Resposta5();

            Console.ReadKey();
        }
                      

        public static void Resposta2()
        {
            Console.WriteLine("-------------------------- Reposta 2 ------------------------------ ");

            int num1 = 0, num2 = 1, aux;
            var list = new List<long>();
            Console.WriteLine("digite um numero: ");
            var number = Convert.ToInt64(Console.ReadLine());


            for (int i = 0; i​​​​​​​ <= number; i++)
            {
                aux = num1;
                num1 = num2;
                num2 = num1 + aux;
                list.Add(num2);
            }

            if (list.Contains(number))
            {
                Console.WriteLine("número dentro da sequencia de fibonacci");
            }
            else
            {
                Console.WriteLine("número não pertence a sequencia de fibonacci");
            }

        }

        public static void Resposta3e4()
        {
            Console.WriteLine("-------------------------- Reposta 3 ------------------------------ ");

            using var file = new StreamReader("C:\\Users\\Bruno\\source\\repos\\test-desenvolvedorSP\\dados.json");

            var faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(file.ReadToEnd());

            var faturamentoFilter = faturamentos.Where(x => x.Valor > 0);

            Console.WriteLine($"Menor dia de faturamento  - {faturamentoFilter.MinBy(x => x.Valor).Dia} - R$ {faturamentoFilter.MinBy(x => x.Valor).Valor}");
            Console.WriteLine($"Maior dia de faturamento  - {faturamentoFilter.MaxBy(x => x.Valor).Dia} - R$ {faturamentoFilter.MaxBy(x => x.Valor).Valor}");
            var mediaMensal = (faturamentos.Sum(x => x.Valor) / faturamentoFilter.Count());

            Console.WriteLine($"------ Dias que o valor foi maior que a média mensal de {mediaMensal} -------");

            faturamentoFilter.Where(x => x.Valor > mediaMensal).ToList().ForEach(x => Console.WriteLine(string.Format("{0} - {1}", x.Dia, x.Valor)));

                var faturamentoMensal = faturamentoFilter.Sum(x => x.Valor);

            Console.WriteLine("-------------------------- Reposta 4 ------------------------------ ");

        }

        private static void Resposta5()
        {
            Console.WriteLine("-------------------------- Reposta 5 ------------------------------ ");

            Console.WriteLine("digite uma palava para ser revertida");
            var word = (string)Console.ReadLine();

            var buidString = new StringBuilder();

            for (int i = word.Length - 1; i >= 0; i--)
            {
                buidString.Append(word[i]);
            }

            Console.WriteLine($"Palavra Invertida: {buidString}");
        }
    }
}