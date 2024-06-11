using System;

namespace PROJETO
{
	//Guarda temporária de dados dos pacientes
	public struct infoPacientes
	{
		public int IDCliente {get; set;}
		public int plano     {get; set;}
		public string nome   {get; set;}
		public string cpf    {get; set;}
		public string email  {get; set;}
		public string data   {get; set;}
		
		//Formato como esses dados devem ser apresentados quando forem chamados!
		public override string ToString()
		{
			return string.Format("|IDCLIENTE: {0}|  NOME: {1}|  CPF: {2}|   EMAIL: {3}|   DATA: {4}|", IDCliente, nome, cpf, email, data);

		}

	}
	
}
