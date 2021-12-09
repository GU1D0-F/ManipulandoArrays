using System;

namespace AulaQuinta
{
    class Program
    {
        static void Main(string[] args)
        {
            Questao1 questao1 = new();
            Questao2 questao2 = new();
            Questao3 questao3 = new();
            int opcao = -1;

            while (opcao != 4)
            {
                Console.WriteLine(" --------------- ");
                Console.WriteLine("| 1 - Questão 1 |");
                Console.WriteLine("| 2 - Questão 2 |");
                Console.WriteLine("| 3 - Questão 3 |");
                Console.WriteLine("| 4 -   Sair    |");
                Console.WriteLine(" --------------- ");

                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                    questao1.Executa();

                if (opcao == 2)
                    questao2.Executa();

                if (opcao == 3)
                    questao3.Executa();
        }

    }

        class Questao1
        {

            public void Executa()
            {
                int contador = 0;
                int[] numeros = new int[25];
                int somaNumeros = 0;
                int maiorNumero = -1;
                int menorNumeroMultiplo5 = 999999999;
                while (contador < 25)
                {
                    Console.WriteLine();
                    Console.Write("Escreva um numero: ");
                    int numero = int.Parse(Console.ReadLine());

                    if (numero % 2 == 0)
                        Console.WriteLine($"{numero} é par");
                    else
                        Console.WriteLine($"{numero} é impar");

                    bool ehPrimo = ValidadorNumeroPrimo(numero);

                    if (ehPrimo)
                        Console.WriteLine($"{numero} é primo");
                    else
                        Console.WriteLine($"{numero} não é primo");

                    if (numero % 5 == 0)
                    {
                        if (numero < menorNumeroMultiplo5)
                        {
                            menorNumeroMultiplo5 = numero;
                        }

                        Console.WriteLine($"{numero} é divisivel por 5");
                    }

                    else
                        Console.WriteLine($"{numero} não é divisivel por 5");

                    if (numero > maiorNumero)
                        maiorNumero = numero;

                    somaNumeros += numero;
                    numeros[contador] = numero;
                    contador++;
                }

                int calculoMedia = CalculaMedia(somaNumeros);
                Console.WriteLine($"Média Aritimética: {calculoMedia}");
                Console.WriteLine($"Maior numero informado: {maiorNumero}");
                Console.WriteLine($"Fatorial do menor múltiplo de 5 informado: {Fatorial(menorNumeroMultiplo5)}");
                NumerosMaiorQueMedia(calculoMedia, numeros);

            }

            private static int CalculaMedia(int somaNumeros, int totalNumerosSomados = 25)
            {
                return somaNumeros / totalNumerosSomados;
            }

            private static bool ValidadorNumeroPrimo(int numero)
            {
                int divisao = 0;

                for (int i = 1; i <= numero; i++)
                {
                    if (numero % i == 0)
                    {
                        divisao++;
                    }
                }

                return divisao == 2;
            }

            private static double Fatorial(int numero)
            {
                double resultado = 1;
                while (numero != 1)
                {
                    resultado = resultado * numero;
                    numero = numero - 1;
                }
                return resultado;
            }

            private static void NumerosMaiorQueMedia(int media, int[] numeros)
            {
                Console.WriteLine("Numeros digitados que foram maior que a Média: ");
                for (int i = 0; i < numeros.Length; i++)
                {
                    if (numeros[i] > media)
                        Console.WriteLine(numeros[i]);
                }
            }

        }

        class Questao2
        {
            public void Executa()
            {
                int[] numeros = new int[20];
                int somaNumeros = 0;
                int somaImparesArray = 0;
                int somaNumerosImpares = 0;
                int contador = 0;
                while (contador < 20)
                {
                    Console.WriteLine();
                    Console.Write("Escreva um numero: ");
                    int numero = int.Parse(Console.ReadLine());
                    somaNumeros += numero;

                    if (contador % 2 != 0)
                        somaImparesArray += numero;

                    if (numero % 2 != 0)
                        somaNumerosImpares += numero;


                    numeros[contador] = numero;
                    contador++;
                }

                int media = somaNumeros / 20;

                Console.WriteLine($"Média aritmética dos números informados: {media}");
                Console.WriteLine($"Qual o somatório dos números que ocupam as posições ímpares do array: {somaImparesArray}");
                Console.WriteLine($"Qual o somatório dos números ímpares existentes na coleção: {somaNumerosImpares}");
                Console.WriteLine($"Existem números repetidos na coleção: {ExistemNumerosRepetidos(numeros)}");
                MostraNumerosMenoresQueMedia(media, numeros);
            }

            private static bool ExistemNumerosRepetidos(int[] numeros)
            {
                for (int i = 0; i < numeros.Length; i++)
                {
                    for (int j = 1; j < numeros.Length; j++)
                    {
                        if (numeros[i] == numeros[j])
                            return true;
                    }
                }

                return false;
            }

            private static void MostraNumerosMenoresQueMedia(int media, int[] numeros)
            {
                Console.WriteLine("Quantos dos números da coleção são menores que a média: ");
                for (int i = 0; i < numeros.Length; i++)
                {
                    if (numeros[i] < media)
                        Console.WriteLine(numeros[i]);
                }
            }
        }

        class Questao3
        {
            public void Executa()
            {
                int[] matriculas = new int[20];
                int[] idades = new int[20];

                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine();
                    Console.Write("Matricula: ");
                    int matricula = int.Parse(Console.ReadLine());

                    while (!ValidaMatricula(matriculas, i, matricula))
                    {
                        Console.WriteLine("Matricula digitada já foi cadastrada");

                        Console.Write("Matricula: ");
                        matricula = int.Parse(Console.ReadLine());
                    }

                    matriculas[i] = matricula;

                    Console.Write("Idade: ");
                    idades[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine();
                Console.WriteLine("Matriculas em ordem de digitação: " + ConverteArrayEmString(matriculas));
                Console.WriteLine("Idades em ordem de digitação: " + ConverteArrayEmString(idades));

                OrdenaEmOrdemCrescente(matriculas, idades);
            }


            private static bool ValidaMatricula(int[] array, int tamanhoArray, int matricula)
            {
                int contador = 0;
                for (int i = 0; i < tamanhoArray; i++)
                {
                    if (matricula == array[i])
                    {
                        contador += 1;
                        if (contador > 0)
                            return false;
                    }
                }
                return true;
            }

            private static string ConverteArrayEmString(int[] dados)
            {
                string retorno = "";

                foreach (int dado in dados)
                {
                    retorno += dado.ToString() + " ";
                }

                return retorno;
            }

            private int[] InverteArrays(int[] array)
            {
                int[] arrayInvertido = new int[20];

                for (int h = 0; h < 20; h++)
                {
                    arrayInvertido[h] = array[array.Length - 1 - h];
                }

                return arrayInvertido;
            }

            private void OrdenaEmOrdemCrescente(int[] matriculas, int[] idades)
            {
                int[] matriculasAux = new int[20];
                int[] idadesAux = new int[20];
                matriculas.CopyTo(matriculasAux, 0);

                Ordernador(matriculas, 0, matriculas.Length - 1);

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (matriculasAux[i] == matriculas[j])
                        {
                            idadesAux[j] = idades[i];
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Matriculas em ordem crescente: " + ConverteArrayEmString(matriculas));
                Console.WriteLine("Respectivas idades: " + ConverteArrayEmString(idadesAux));

                int[] matriculasInvertidas = InverteArrays(matriculas);
                int[] idadaesInvertidas = InverteArrays(idadesAux);

                Console.WriteLine();
                Console.WriteLine("Matriculas invertidas: " + ConverteArrayEmString(matriculasInvertidas));
                Console.WriteLine("Idades invertidas: " + ConverteArrayEmString(idadaesInvertidas));
            }

            private static void Ordernador(int[] arr, int esquerda, int direita)
            {
                if (esquerda < direita)
                {
                    int pivot = Particiona(arr, esquerda, direita);

                    if (pivot > 1)
                    {
                        Ordernador(arr, esquerda, pivot - 1);
                    }
                    if (pivot + 1 < direita)
                    {
                        Ordernador(arr, pivot + 1, direita);
                    }
                }
            }

            private static int Particiona(int[] arr, int esquerda, int direita)
            {
                int pivot = arr[esquerda];
                while (true)
                {
                    while (arr[esquerda] < pivot)
                    {
                        esquerda++;
                    }
                    while (arr[direita] > pivot)
                    {
                        direita--;
                    }
                    if (esquerda < direita)
                    {
                        if (arr[esquerda] == arr[direita]) return direita;
                        int temp = arr[esquerda];
                        arr[esquerda] = arr[direita];
                        arr[direita] = temp;
                    }
                    else
                    {
                        return direita;
                    }
                }
            }
        }
    }
}
