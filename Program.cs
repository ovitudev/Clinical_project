using System;
using System.Threading;

namespace PROJETO
{
	class Program
	{
		//Corpo principal do programa
		public static void Main(string[] args)
		{
			//Iniciando as funções
			funcoes fc = new funcoes();

			//Iniciando a leitura de teclas para navegação do programa
			ConsoleKeyInfo keyinfo;
			
			fc.telaLogin();
			do{
				
				fc.menuPrincipal();
				keyinfo = Console.ReadKey(true);//Leitor Menu principal
				
				switch(keyinfo.Key)//Opções do Menu Principal
				{
					case ConsoleKey.D1:
					case ConsoleKey.NumPad1:
						
						Console.Clear();
						fc.menuPaciente();//Apresenta a função menuPaciente
						keyinfo = Console.ReadKey(true);
						
						switch(keyinfo.Key)//Opções Menu Paciente
						{
							case ConsoleKey.D1:
							case ConsoleKey.NumPad1:
								Console.Clear();
								fc.infoPaciente();//Apresenta a função infoPaciente
								continue;
								
							case ConsoleKey.D2:
							case ConsoleKey.NumPad2:
								Console.Clear();
								fc.menuAgendamento();//Apresenta a função menuAgendamento
								Console.Clear();
								continue;
								
								//Opção para voltar a tela
							case ConsoleKey.D3:
							case ConsoleKey.NumPad3:
								Console.Clear();
								continue;
								
								//Opção para encerrar
							case ConsoleKey.D4:
							case ConsoleKey.NumPad4:
								Console.Clear();
								break;
								
							default:
								Console.Clear();
								break;
						}
						continue;
					case ConsoleKey.D2:
					case ConsoleKey.NumPad2:
						fc.consultaCad();//Apresenta cadastros realizados na seção
						continue;
						
					case ConsoleKey.D3:
					case ConsoleKey.NumPad3:
						Console.Clear();
						fc.menuSimulador();//Apresenta a função menuSimulador
						Console.Clear();
						continue;
						
					case ConsoleKey.D4:
					case ConsoleKey.NumPad4:
						Console.Clear();
						fc.informacoes();//Apresenta a função informações
						Console.Clear();
						continue;
						
						//Encerra o programa
					case ConsoleKey.D5:
					case ConsoleKey.NumPad5:
						Console.Clear();
						Console.WriteLine("SELECIONE QUALQUER TECLA PARA ENCERRAR O PROGRAMA!");
						break;
						
						//Opção para caso selecione uma opção que não exista
					default:
						Console.Clear();
						continue;
				}
				Console.ReadKey(true);
				continue;
			}while(keyinfo.Key != ConsoleKey.NumPad5);//Condição do do/While
		}
	}
}