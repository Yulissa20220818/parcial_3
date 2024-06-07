using System;
using System.Media;

class AdivinaElNumero
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int intentos = 0;
        bool adivinado = false;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("¡Bienvenido al juego de Adivina el Número!");
        Console.ResetColor();

        while (!adivinado)
        {
            intentos++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Adivina el número (entre 1 y 100): ");
            Console.ResetColor();

            string input = Console.ReadLine();
            int numeroUsuario;

            if (int.TryParse(input, out numeroUsuario))
            {
                if (numeroUsuario == numeroSecreto)
                {
                    adivinado = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡Felicidades! Adivinaste el número en {0} intentos.", intentos);
                    Console.ResetColor();
                    PlaySound("win.wav");
                }
                else if (numeroUsuario < numeroSecreto)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("El número secreto es mayor. Intenta nuevamente.");
                    Console.ResetColor();
                    PlaySound("wrong.wav");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El número secreto es menor. Intenta nuevamente.");
                    Console.ResetColor();
                    PlaySound("wrong.wav");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Entrada no válida. Por favor ingresa un número.");
                Console.ResetColor();
                PlaySound("error.wav");
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
        Console.ResetColor();
    }

    static void PlaySound(string soundFileName)
    {
        try
        {
            using (var player = new SoundPlayer(soundFileName))
            {
                player.Load();
                player.Play();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error al reproducir el sonido: " + ex.Message);
            Console.ResetColor();
        }
    }
}
