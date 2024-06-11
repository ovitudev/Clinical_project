using System;
using System.Threading;

namespace PROJETO
{
	public class funcoes
	{
		//Inicializando minha função vetores e minha estrutura de forma que possam ser utilizadas dentro da classe
		public vetores VT = new vetores();
		public infoPacientes[] vinfoPacientes;
		public infoPacientes paciente;
		
		public void telaLogin()//Será responsável por permitir a navegação do usuário ou não
		{
			string usuario, senha;

			do{
				
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine("|==================================================TELA LOGIN=========================================================|");
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine();
				Console.Write("                                                USUÁRIO: ");
				usuario = Console.ReadLine().ToUpper();
				Console.WriteLine();
				Console.Write("                                                SENHA  : ");
				senha = Console.ReadLine();
				Console.WriteLine();
				if((usuario == "ADM2024") && (senha == "marcos3197"))//Dados utilizados para permitir a entrada
				{
					Console.WriteLine("|===============================================LOGIN FEITO COM SUCESSO===============================================|");
					Console.WriteLine("                                                       AGUARDE                                                         ");
					Thread.Sleep(1400);
					Console.Clear();
					break;
				}
				Console.WriteLine("                                           LOGIN OU SENHA INVÁLIDOS!                                                       ");
				Thread.Sleep(2000);
				Console.Clear();
				
			}while((usuario != "ADM2024") || (senha != "marcos3197"));//Condição para que entre no programa em si
		}
		public void menuPrincipal()//Apresenta as opções de navegação no programa
		{
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|=================================================MENU PRINCIPAL======================================================|");
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|1. PACIENTE                                                                                                          |");
			Console.WriteLine("|2. CONSULTAR CADASTROS                                                                                               |");
			Console.WriteLine("|3. SIMULADOR DE VALORES                                                                                              |");
			Console.WriteLine("|4. INFORMAÇÕES                                                                                                       |");
			Console.WriteLine("|5. ENCERRAR PROGRAMA                                                                                                 |");
			Console.WriteLine("|=====================================================================================================================|");
		}
		public void menuPaciente()//Apresenta as opções de interação no menuPaciente
		{
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|==================================================MENU PACIENTE======================================================|");
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|1. CADASTRO                                                                                                          |");
			Console.WriteLine("|2. AGENDAMENTO                                                                                                       |");
			Console.WriteLine("|3. VOLTAR                                                                                                            |");
			Console.WriteLine("|4. ENCERRAR PROGRAMA                                                                                                 |");
			Console.WriteLine("|=====================================================================================================================|");
		}
		public static bool validadorCPF(string cpf)//Responsável pela verificação do CPF, de acordo com o cálculo nacional
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int i;

			cpf = cpf.Trim().Replace(".", "").Replace("-", "");//Retira pontos, traços e espaços do cpf digitado
			if (cpf.Length != 11)
				return false;

			for (int j = 0; j < 10; j++)
				if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)//Verifica se dos 11 digitos todos foram iguais ou não
					return false;

			string tempCpf = cpf.Substring(0, 9);//Separa os 9 primeiros digitos do CPF para realizar o cálculo dos digitos verificadores
			int soma = 0;

			for (i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

			int resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			string digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
			
		}
		public void infoPaciente()
		{
			Random rnd = new Random();//Inicio uma sintaxe de números aleatorios para gerar meus id's
			Console.WriteLine("|==================================================INFO PACIENTE======================================================|");
			Console.WriteLine("|=====================================================================================================================|");
			Console.Write("|INFORME QUANTOS PACIENTES SERÃO CADASTRADOS: ");
			VT.quantPacientes = int.Parse(Console.ReadLine());    //"Guardo" a quantidade de clientes que vão ser armazenados
			vinfoPacientes = new infoPacientes[VT.quantPacientes];//Inicializo o tamanho da minha struct
			
			if(VT.quantPacientes <= 0)
			{
			Console.WriteLine("                            INFORME UMA QUANTIDADE DE PACIENTES PARA CADASTRO MAIOR QUE 0!!");
			Thread.Sleep(1800);
			Console.Clear();
			}
			
			for(int i=0; i<VT.quantPacientes; i++)
			{
				vinfoPacientes[i] = new infoPacientes();//Retorno os valores para a struct
				Console.WriteLine("|=====================================================================================================================|");
				Console.Write("|IDCliente: ");
				vinfoPacientes[i].IDCliente = rnd.Next(1,500);
				Console.WriteLine(vinfoPacientes[i].IDCliente);//ID gerado de forma aleatoria
				
				Console.Write("|Nome: ");
				vinfoPacientes[i].nome = Console.ReadLine().ToUpper();
				if(vinfoPacientes[i].nome == "")//Verifica se foi preenchido
				{
					Console.WriteLine("|                                       NENHUM NOME DIGITADO, TENTE NOVAMENTE!                                        |");
					Thread.Sleep(3000);
					Console.Clear();
					i--;//Caso caia nesse IF, irá recontar meu valor i, de forma que reinicializa de acordo
					continue;
				}
				
				Console.Write("|CPF: ");
				vinfoPacientes[i].cpf = Console.ReadLine();
				
				if(!validadorCPF(vinfoPacientes[i].cpf)){
					Console.WriteLine("|CPF INVÁLIDO, TENTE NOVAMENTE!                                                                                      |");
					Thread.Sleep(3000);
					Console.Clear();
					i--;//Caso caia nesse IF, irá recontar meu valor i, de forma que reinicializa de acordo
					continue;
				}
				
				Console.Write("|E-mail: ");
				vinfoPacientes[i].email = Console.ReadLine().ToUpper();
				if(vinfoPacientes[i].email == "")//Verifica se foi preenchido
				{
					Console.WriteLine("|                                           EMAIL INVÁLIDO, TENTE NOVAMENTE!                                         ");
					i--;//Caso caia nesse IF, irá recontar meu valor i, de forma que reinicializa de acordo
					continue;
				}
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine("|                           CADASTRO REALIZADO COM SUCESSO...  PRESSIONE ENTER PARA CONTINUAR!                        |");
				Console.ReadKey(true);
				Console.Clear();
				continue;
			}
		}
		public void consultaCad()
		{
			Console.Clear();
			while(VT.quantPacientes != 0){
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine("|=================================================PACIENTES CADASTRADOS===============================================|");
				Console.WriteLine("|=====================================================================================================================|");
				if(VT.quantPacientes == 0)//Verifica se há pacientes cadastrados
				{
					Console.WriteLine("|                                  CADASTRE PACIENTES ANTES DE UTILIZAR ESSA OPÇÃO...                                 |");
					Console.WriteLine("|                                       PRESSIONE QUALQUER TECLA PARA CONTINUAR!                                      |");
					Console.ReadKey(true);
					Console.Clear();
					break;
				}
				for(int i=0; i<VT.quantPacientes; i++)//Laço de repetição de acordo com o tamanho da minha estrutura e dos cadastros realizados
				{
					Console.WriteLine(vinfoPacientes[i]);//Apresenta cada cadastro feito na estrutura
				}
				Console.WriteLine("|======================================PRESSIONE QUALQUER TECLA PARA CONTINUAR========================================|");
				Console.ReadKey(true);
				Console.Clear();
				break;
			}
		}
		public void menuAgendamento()
		{
			if((vinfoPacientes == null )|| (vinfoPacientes.Length == 0))//Verifica se há pacientes cadastrados para poder continuar com essa ação
			{
				Console.WriteLine("|                                      NENHUM PACIENTE CADASTRADO! TENTE NOVAMENTE...                                 |");
				return;
			}
			
			for(int i=0; i<VT.quantPacientes; i++){
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine("|================================================MENU AGENDAMENTO=====================================================|");
				Console.WriteLine("|=====================================================================================================================|");
				Console.Write("|INFORME O ID DO PACIENTE PARA REALIZAR O AGENDAMENTO: ");
				int idPaciente = int.Parse(Console.ReadLine());//Recebe o ID do cliente que deseja agendar
				paciente = Array.Find(vinfoPacientes, p => p.IDCliente == idPaciente);//Procura de acordo com o parametro da struct (no caso IDCliente) e compara com o que procura
				if(paciente.IDCliente != 0)//Verifica se o valor é diferente de 0 para poder dar continuidade
				{
					Console.Write("|INFORME A DATA QUE DESEJA AGENDAR <dd/mm>: ");
					paciente.data = Console.ReadLine();
					
					Console.WriteLine("                             AGENDAMENTO REALIZADO PARA O(A) PACIENTE '{0}' NA DATA {1}!!                              ", paciente.nome, paciente.data);
					Console.WriteLine("                                  DESEJA FAZER MAIS ALGUM AGENDAMENTO? <S/N>                                           ");
					vinfoPacientes[Array.FindIndex(vinfoPacientes, p => p.IDCliente == idPaciente)] = paciente;
					
					string opcAgendamento = Console.ReadLine().ToUpper();
					if(opcAgendamento == "S")
					{
						continue;
					}
					else
					{
						break;
					}
				}
				Console.WriteLine("                                          PRESSIONE ENTER PARA CONTINUAR!                                                ");
				Console.ReadKey(true);
			}
		}
		public void menuSimulador()
		{
			//Vetores com valores já inseridos para fácil utilização na montagem da tabela
			string[] vConsultas = new string [5]{"Pediatra", "Psquiatra", "Nutricionista", "Médico Clinico", "Consulta Eletiva"};
			double[] vValores = new double   [5]{129.00, 117.00, 61.55, 117.00, 88.00};
			string[] vExames = new string    [5]{"Ultrassonografia", "Biopsia de prostata", "Audiometria", "Ecocardiograma", "Polissonografia"};
			double[] vValores2 = new double  [5]{48.40, 165.12, 43.75, 85.06, 351.50};
			string[] vCirurgia = new String  [5]{"Otoplastia", "Protese de coxa", "Mamoplastia", "Lipoaspiração", "Ressutura"};
			double[] vValores3 = new double  [5]{1350.00, 1750.00, 2300.00, 2300.00, 1050.00};
			
			//Inicializando variaveis para cálculos
			double soma = 0;//Acumula as opções selecionadas pelo usuário até que selecione a opção de TOTAL
			double total = 0;
			double desc = 0;
			
			//Inicializando o leitor de tecla para interação do usuário no menuSimulador
			ConsoleKeyInfo keyinfoPlan;
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|SELECIONE UM DOS SEGUINTES PLANOS:                                                                                   |");
			Console.WriteLine("|1. PLANO EMPRESARIAL(100%)                                                                                           |");
			Console.WriteLine("|2. PLANO PESSOAL(90%)                                                                                                |");
			Console.WriteLine("|3. PLANO AVULSO                                                                                                      |");
			Console.WriteLine("|=====================================================================================================================|");
			keyinfoPlan = Console.ReadKey(true);
			//Desconto do simulador de acordo com os planos
			switch(keyinfoPlan.Key)
			{
				case ConsoleKey.NumPad1:
				case ConsoleKey.D1:
					desc = 100;
					break;
					
				case ConsoleKey.NumPad2:
				case ConsoleKey.D2:
					desc = 90;
					break;
					
				case ConsoleKey.NumPad3:
				case ConsoleKey.D3:
					desc = 0;
					break;
				default:
					Console.Clear();
					break;
			}
			
			//Reinicializando leitor de interação para não gerar conflito
			ConsoleKeyInfo keyinfoMS;
			do{
				Console.Clear();
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine("|=================================================MENU SIMULAÇÃO======================================================|");
				Console.WriteLine("|=====================================================================================================================|");
				Console.WriteLine("|1. CONSULTAS                                                                                                         |");
				Console.WriteLine("|2. EXAMES                                                                                                            |");
				Console.WriteLine("|3. CIRURGIAS                                                                                                         |");
				Console.WriteLine("|4. TOTAL                                                                                                             |");
				Console.WriteLine("|5. SAIR                                                                                                              |");
				Console.WriteLine("|=====================================================================================================================|");
				keyinfoMS = Console.ReadKey(true);
				
				//Escolha das opções apresentadas pelo menu
				switch(keyinfoMS.Key){
					case ConsoleKey.NumPad1:
					case ConsoleKey.D1:
						Console.Clear();
						
						//Reinicializo o leitor para interação sem conflito
						ConsoleKeyInfo keyinfo1;
						Console.WriteLine("|=====================================================================================================================|");
						Console.WriteLine("|================================================VALORES CONSULTAS====================================================|");
						//Retorno do vetor de vConsultas e vValores
						for(int i=0; i<5; i++)
						{
							Console.WriteLine("{0}. {1}: R${2}", i + 1, vConsultas[i], vValores[i]);
						}
						keyinfo1 = Console.ReadKey(true);
						
						switch(keyinfo1.Key)
						{
							case ConsoleKey.D1:
							case ConsoleKey.NumPad1:
								soma += vValores[0];
								continue;
							case ConsoleKey.D2:
							case ConsoleKey.NumPad2:
								soma += vValores[1];
								continue;
							case ConsoleKey.D3:
							case ConsoleKey.NumPad3:
								soma += vValores[2];
								continue;
							case ConsoleKey.D4:
							case ConsoleKey.NumPad4:
								soma += vValores[3];
								continue;
							case ConsoleKey.D5:
							case ConsoleKey.NumPad5:
								soma += vValores[4];
								continue;
							default:
								continue;
						}
					case ConsoleKey.NumPad2:
					case ConsoleKey.D2:
						Console.Clear();
						
						//Reinicializo o leitor para interação sem conflito
						ConsoleKeyInfo keyinfo2;
						Console.WriteLine("|=====================================================================================================================|");
						Console.WriteLine("|==================================================VALORES EXAMES=====================================================|");
						//Retorno do vetor de vExames e vValores2
						for(int i=0; i<5; i++)
						{
							Console.WriteLine("{0}. {1}: R${2}", i + 1, vExames[i], vValores2[i]);
						}
						keyinfo2 = Console.ReadKey(true);
						
						switch(keyinfo2.Key)
						{
							case ConsoleKey.D1:
							case ConsoleKey.NumPad1:
								soma += vValores2[0];
								continue;
							case ConsoleKey.D2:
							case ConsoleKey.NumPad2:
								soma += vValores2[1];
								continue;
							case ConsoleKey.D3:
							case ConsoleKey.NumPad3:
								soma += vValores2[2];
								continue;
							case ConsoleKey.D4:
							case ConsoleKey.NumPad4:
								soma += vValores2[3];
								continue;
							case ConsoleKey.D5:
							case ConsoleKey.NumPad5:
								soma += vValores2[4];
								continue;
							default:
								continue;
						}
						
					case ConsoleKey.NumPad3:
					case ConsoleKey.D3:
						Console.Clear();
						
						//Reinicializo o leitor para interação sem conflito
						ConsoleKeyInfo keyinfo3;
						Console.WriteLine("|=====================================================================================================================|");
						Console.WriteLine("|================================================VALORES CIRURGIAS====================================================|");
						//Retorno do vetor de vCirurgia e vValores3
						for(int i=0; i<5; i++)
						{
							Console.WriteLine("{0}. {1}: R${2}", i + 1, vCirurgia[i], vValores3[i]);
						}
						keyinfo3 = Console.ReadKey(true);
						
						switch(keyinfo3.Key)
						{
							case ConsoleKey.D1:
							case ConsoleKey.NumPad1:
								soma += vValores3[0];
								continue;
							case ConsoleKey.D2:
							case ConsoleKey.NumPad2:
								soma += vValores3[1];
								continue;
							case ConsoleKey.D3:
							case ConsoleKey.NumPad3:
								soma += vValores3[2];
								continue;
							case ConsoleKey.D4:
							case ConsoleKey.NumPad4:
								soma += vValores3[3];
								continue;
							case ConsoleKey.D5:
							case ConsoleKey.NumPad5:
								soma += vValores3[4];
								continue;
							default:
								continue;
						}
						
					case ConsoleKey.D4:
					case ConsoleKey.NumPad4:
						Console.Clear();
						//Realiza a simulção de acordo com as seleções do usuário
						total = (soma - (desc / 100 * soma));
						Console.WriteLine("|=====================================================================================================================|");
						Console.WriteLine("|==================================================VALOR SIMULADO=====================================================|");
						Console.WriteLine("|                                                                                                                     |");
						Console.WriteLine("                                                TOTAL SIMULADO: R${0}",total.ToString("F2"));
						Console.WriteLine("|                                                                                                                     |");
						Console.WriteLine("|======================================PRESSIONE QUALQUER TECLA PARA CONTINUAR========================================|");
						Console.ReadKey(true);
						break;
						
					case ConsoleKey.D5:
					case ConsoleKey.NumPad5:
						Console.Clear();
						break;
						
					default:
						continue;
				}
				break;
			}while(keyinfoMS.Key != ConsoleKey.NumPad5);//Condição para manter rodando o simulador
		}
		public void informacoes()//Gera as informações da clinica
		{
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|====================================================INFORMAÇÕES======================================================|");
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|ESTAMOS LOCALIZADOS NA RUA FICTICIA, N° 777, BAIRRO IMAGINÁRIO - MG                                                  |\n" +
			                  "|CELULAR: (31)4002-8922 / (31)7070-7070                                                                               |\n" +
			                  "|EMAIL: CLINICASAUDEEBEMESTAR@FICTICIO.COM.BR                                                                         |\n" +
			                  "|PAGAMENTOS APENAS CARTÃO OU PIX!                                                                                     |");
			Console.WriteLine("|=====================================================================================================================|");
			Console.WriteLine("|======================================PRESSIONE QUALQUER TECLA PARA CONTINUAR========================================|");
			Console.ReadKey(true);
		}
	}
}
public class vetores//Responsável por armazenar quantos Pacientes vão ser cadastrados na sessão
{
	public int quantPacientes {get; set;}
}