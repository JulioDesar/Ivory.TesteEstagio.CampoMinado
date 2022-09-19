﻿using System;
using System.Threading;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!
            Random rnd = new Random();
            int linha = rnd.Next(0, 9);
            int coluna = rnd.Next(0, 9);
            string[] campo = campoMinado.Tabuleiro.Split("\r\n");
            AtribuirCampo(campo);

            while (campoMinado.JogoStatus == 0)
            {
                if (CampoTabuleiro[linha, coluna] == "-")
                {
                    campo = campoMinado.Tabuleiro.Split("\r\n");
                    AtribuirCampo(campo);
                    AtribuirBandeira(linha, coluna);
                    Console.WriteLine($"Abrindo casa: linha({linha}) / coluna({coluna})");
                    Jogar(campoMinado, linha, coluna);
                    Console.WriteLine("----------- Status: Jogo em aberto -----------");
                    Console.WriteLine(campoMinado.Tabuleiro);
                    linha = rnd.Next(0, 9);
                    coluna = rnd.Next(0, 9);
                    Console.WriteLine("");
                    Thread.Sleep(2000);

                }
                else
                {
                    linha = rnd.Next(0, 9);
                    coluna = rnd.Next(0, 9);
                }

            }

            Console.WriteLine(campoMinado.Tabuleiro);

        }

        public static void Jogar(CampoMinado campoMinado, int linha, int coluna)
        {
            if (campoMinado.JogoStatus == 0)
            {
                if (Bandeiras[linha, coluna] == false)
                {


                    
                    campoMinado.Abrir(linha + 1, coluna + 1);


                }

            }
        }

        public static void AtribuirCampo(String[] campo)
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (campo[i].IndexOf("0", j) == j)
                    {
                        CampoTabuleiro[i, j] = "0";
                    }

                    if (campo[i].IndexOf("1", j) == j)
                    {
                        CampoTabuleiro[i, j] = "1";
                    }

                    if (campo[i].IndexOf("2", j) == j)
                    {
                        CampoTabuleiro[i, j] = "2";
                    }

                    if (campo[i].IndexOf("3", j) == j)
                    {
                        CampoTabuleiro[i, j] = "3";
                    }

                    if (campo[i].IndexOf("4", j) == j)
                    {
                        CampoTabuleiro[i, j] = "4";
                    }
                    if (campo[i].IndexOf("5", j) == j)
                    {
                        CampoTabuleiro[i, j] = "5";
                    }
                    if (campo[i].IndexOf("6", j) == j)
                    {
                        CampoTabuleiro[i, j] = "6";
                    }
                    if (campo[i].IndexOf("7", j) == j)
                    {
                        CampoTabuleiro[i, j] = "7";
                    }
                    if (campo[i].IndexOf("8", j) == j)
                    {
                        CampoTabuleiro[i, j] = "8";
                    }
                    if (campo[i].IndexOf("*", j) == j)
                    {
                        CampoTabuleiro[i, j] = "*";
                    }
                }
            }
        }

        public static string Tabuleiro
        {
            get
            {
                var tabuleiro = "";

                for (var x = 0; x < 9; x++)
                {
                    for (var y = 0; y < 9; y++)
                    {
                        tabuleiro += CampoTabuleiro[x, y];
                    }

                    if (x != 8)
                    {
                        tabuleiro += "\r\n";
                    }
                }

                return tabuleiro;
            }
        }

        public static string ImprimirBandeiras
        {
            get
            {
                var tabuleiro = "";

                for (var x = 0; x < 9; x++)
                {
                    for (var y = 0; y < 9; y++)
                    {
                        tabuleiro += Bandeiras[x, y] + " ";
                    }

                    if (x != 8)
                    {
                        tabuleiro += "\r\n";
                    }
                }

                return tabuleiro;
            }
        }

        public static void AtribuirBandeira(int linha, int coluna)
        {
            if (linha == 0 && coluna == 0)
            {
                if (CampoTabuleiro[linha, coluna] != "-" && CampoTabuleiro[linha, coluna] != "0")
                {

                    Bandeiras[linha, coluna - 1] = true;
                    Bandeiras[linha - 1, coluna] = true;
                    Bandeiras[linha - 1, coluna - 1] = true;

                }

                if (CampoTabuleiro[linha, coluna] == "0")
                {

                    Bandeiras[linha, coluna] = false;

                }
            }

            if (linha == 8 && coluna == 8)
            {
                if (CampoTabuleiro[linha, coluna] != "-" && CampoTabuleiro[linha, coluna] != "0")
                {

                    Bandeiras[linha, coluna] = true;

                }

                if (CampoTabuleiro[linha, coluna] != "0")
                {

                    Bandeiras[linha, coluna + 1] = false;
                    Bandeiras[linha + 1, coluna] = false;
                    Bandeiras[linha + 1, coluna + 1] = false;
                }
            }

            if ((linha >= 1 && linha <= 7) && (coluna >= 1 && coluna <= 7))
            {
                if (CampoTabuleiro[linha, coluna] != "-" && CampoTabuleiro[linha, coluna] != "0")
                {
                    Bandeiras[linha - 1, coluna - 1] = true;
                    Bandeiras[linha - 1, coluna] = true;
                    Bandeiras[linha - 1, coluna + 1] = true;
                    Bandeiras[linha, coluna - 1] = true;
                    Bandeiras[linha, coluna + 1] = true;
                    Bandeiras[linha + 1, coluna - 1] = true;
                    Bandeiras[linha + 1, coluna] = true;
                    Bandeiras[linha + 1, coluna + 1] = true;
                }

                if (CampoTabuleiro[linha, coluna] != "0")
                {
                    Bandeiras[linha, coluna] = false;
                    Bandeiras[linha - 1, coluna - 1] = false;
                    Bandeiras[linha - 1, coluna] = false;
                    Bandeiras[linha - 1, coluna + 1] = false;
                    Bandeiras[linha, coluna - 1] = false;
                    Bandeiras[linha, coluna + 1] = false;
                    Bandeiras[linha + 1, coluna - 1] = false;
                    Bandeiras[linha + 1, coluna] = false;
                    Bandeiras[linha + 1, coluna + 1] = false;
                }
            }
        }

        private static readonly bool[,] Bandeiras = new bool[9, 9] {
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false },
             { false, false, false, false, false, false, false, false, false }
         };

        private static string[,] CampoTabuleiro = new string[9, 9]
        {
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-" }
        };
    }
}
