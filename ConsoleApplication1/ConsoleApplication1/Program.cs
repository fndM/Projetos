using System.Net.Mime;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// Método Main
        /// </summary>
        static void Main()
        {
            Program p = new Program();

            //Passando variávies para retorno de data futura
            var dataMais = p.ChangeDate("01/03/2010 23:00", '+', 4000);

            //Passando variávies para retorno de data retroativa
            var dataMenos = p.ChangeDate("01/03/2010 23:00", '-', 4000);
        }

        /// <summary>
        /// Método que retorna data com base em uma variável do tipo string, sem utilização de DateTime ou TimeSpan
        /// </summary>
        public string ChangeDate(string date, char op, long value)
        {
            //Declare variável dias
            int dias = 0;
            //Retorna dia de date
            var dia = int.Parse(date.Substring(0,2));
            //Retorna mês de date
            var mes = int.Parse(date.Substring(3,2));
            //Retorna ano de date
            var ano = int.Parse(date.Substring(6,4));
            //Retorna horas de date
            var horasDate = int.Parse(date.Substring(11,2));
            //Retorna minutos de date
            var minutosDate = int.Parse(date.Substring(14,2));

            //Valida se variável op é diferente de + e -
            if (!ValidaOperador(op.ToString()))
                return "Operador inválido";

            //Converte value em horas
            var horas = value / 60;

            //Converte value em minutos
            var minutos = value % 60;

            //Verifica se horas é maior que 24
            if (horas > 24)
            {
                //Converte horas em dias
                dias = (int)horas / 24;
                //Converte resto de horas em horas
                horas = horas % 24;
            }

            //Verfica se op é positivou ou negativo
            if (op.ToString() == "+") //Se positivo entra
            {
                //Valida minutos
                for (var i = (int) minutos; i > 0; i--)
                {
                    //Incrementa minutos
                    minutosDate = minutosDate + 1;
                    //Valida se horasDate é igual a 60
                    if (horasDate == 60)
                    {
                        //Determina valor de minutosDate para 0
                        minutosDate = 0;
                        //Incrementa horasDate
                        horasDate = horasDate + 1;
                        //Valida se horasDate é igual a 24
                        if (horasDate == 24)
                        {
                            //Determina valor de horasDate para 0
                            horasDate = 0;
                            //Incrementa dia
                            dia = dia + 1;
                            //Valida se mês será incrementado
                            if (MesFinalizado(dia, mes))
                            {
                                //Incrementa mes
                                mes = mes + 1;
                                //Determina valor de dia para 1
                                dia = 1;
                                //Valida se mês igual a 13
                                if (mes == 13)
                                {
                                    //Incrementa ano
                                    ano = ano + 1;
                                    //Determina valor de mes para 1
                                    mes = 1;
                                }
                            }
                        }
                    }
                }

                //Valida Horas
                for (var i = (int) horas; i > 0; i--)
                {
                    //Incrementa horasDate
                    horasDate = horasDate + 1;
                    //Valida se horasDate é igual a 24
                    if (horasDate == 24)
                    {
                        //Determina valor de horasDate para 0
                        horasDate = 0;
                        //Incrementa dia
                        dia = dia + 1;
                        //Valida se mês será incrementado
                        if (MesFinalizado(dia, mes))
                        {
                            //Incrementa mes
                            mes = mes + 1;
                            //Determina valor de dia para 1
                            dia = 1;
                            //Valida se mês igual a 13
                            if (mes == 13)
                            {
                                //Incrementa ano
                                ano = ano + 1;
                                //Determina valor de mes para 1
                                mes = 1;
                            }
                        }
                    }
                }

                //Valida dias
                for (var i = dias; i > 0; i--)
                {
                    //Valida se mês será incrementado
                    if (MesFinalizado(dia, mes))
                    {
                        //Incrementa mes
                        mes = mes + 1;
                        //Determina valor de dia para 1
                        dia = 1;
                        //Valida se mês igual a 13
                        if (mes == 13)
                        {
                            //Incrementa ano
                            ano = ano + 1;
                            //Determina valor de mes para 1
                            mes = 1;
                        }
                    }
                    else
                        //Incrementa dia
                        dia = dia + 1;
                }
            }
            else //Se negativo entra
            {
                //Valida minutos
                for (var i = (int)minutos; i > 0; i--)
                {
                    //Reduz minutosDate
                    minutosDate = minutosDate - 1;
                    //Valida se minutosDate é igual a -1
                    if (minutosDate == -1)
                    {
                        //Determina valor de minutosDate para 59
                        minutosDate = 59;
                        //Reduz horasDate
                        horasDate = horasDate - 1;
                        //Valida se horasDate é igual a -1
                        if (horasDate == -1)
                        {
                            //Determina valor de horasDate para 23
                            horasDate = 23;
                            //Reduz dia
                            dia = dia - 1;
                            //Valida se dia é igual a 0
                            if (dia == 0)
                            {
                                //Reduz mes
                                mes = mes - 1;
                                //Valida se mes é igual a 0
                                if (mes == 0)
                                {
                                    //Determina valor mes para 1
                                    mes = 1;
                                    //Reduz ano
                                    ano = ano - 1;
                                }

                                //Determina valor dia para último dia do mês informado
                                dia = UltimoDiaMes(mes);
                            }
                        }
                    }
                }

                //valida Horas
                for (var i = (int)horas; i > 0; i--)
                {
                    //Reduz horasDate
                    horasDate = horasDate - 1;
                    //Valida se horasDate é igual a -1
                    if (horasDate == -1)
                    {
                        //Determina valor de horasDate para 23
                        horasDate = 23;
                        //Reduz dia
                        dia = dia - 1;
                        //Valida se dia é igual a 0
                        if (dia == 0)
                        {
                            //Reduz mes
                            mes = mes - 1;
                            //Valida se mes é igual a 0
                            if (mes == 0)
                            {
                                //Determina valor mes para 1
                                mes = 1;
                                //Reduz ano
                                ano = ano - 1;
                            }

                            //Determina valor dia para último dia do mês informado
                            dia = UltimoDiaMes(mes);
                        }
                    }
                }

                //valida dias
                for (var i = dias; i > 0; i--)
                {
                    //Reduz dia
                    dia = dia - 1;
                    //Valida se dia é igual a 0
                    if (dia == 0)
                    {
                        //Reduz mes
                        mes = mes - 1;
                        //Valida se mes é igual a 0
                        if (mes == 0)
                        {
                            //Determina valor mes para 1
                            mes = 1;
                            //Reduz ano
                            ano = ano - 1;
                        }
                        //Determina valor dia para último dia do mês informado
                        dia = UltimoDiaMes(mes);
                    }
                }
            }

            //Retorna data para variável retornaData
            string retornaData = dia.ToString("00") + "/" + mes.ToString("00") + "/" + ano + " " + horasDate.ToString("00") + ":" + minutosDate.ToString("00");
            //Retorna Data
            return retornaData;
        }

        /// <summary>
        /// Método que valida se op é igual a + ou -
        /// </summary>
        public bool ValidaOperador(string op)
        {
            if (op != "+" && op != "-")
                //Retorna falso
                return false;

            //Retorna verdadeiro
            return true;
        }

        /// <summary>
        /// Metódo que retorna se mês deve ser incrementado
        /// </summary>
        public bool MesFinalizado(int dia, int mes)
        {
            //Declara variável novoDia com valor dia++
            int novoDia = dia++;
            var ultimoDia = 0;

            if (mes == 1)
                ultimoDia = int.Parse(Meses.Janeiro);
            if (mes == 2)
                ultimoDia = int.Parse(Meses.Fevereiro);
            if (mes == 3)
                ultimoDia = int.Parse(Meses.Marco);
            if (mes == 4)
                ultimoDia = int.Parse(Meses.Abril);
            if (mes == 5)
                ultimoDia = int.Parse(Meses.Maio);
            if (mes == 6)
                ultimoDia = int.Parse(Meses.Junho);
            if (mes == 7)
                ultimoDia = int.Parse(Meses.Julho);
            if (mes == 8)
                ultimoDia = int.Parse(Meses.Agosto);
            if(mes == 9)
                ultimoDia = int.Parse(Meses.Setembro);
            if(mes == 10)
                ultimoDia = int.Parse(Meses.Outubro);
            if(mes == 11)
                ultimoDia = int.Parse(Meses.Novembro);
            if(mes == 12)
                ultimoDia = int.Parse(Meses.Dezembro);

            if (novoDia <= ultimoDia)
                return false;

            return true;
        }

        /// <summary>
        /// Método que retorna último dia de mês informado
        /// </summary>
        public int UltimoDiaMes(int mes)
        {
            var ultimoDia = 0;

            if (mes == 1)
                ultimoDia = int.Parse(Meses.Janeiro);
            if (mes == 2)
                ultimoDia = int.Parse(Meses.Fevereiro);
            if (mes == 3)
                ultimoDia = int.Parse(Meses.Marco);
            if (mes == 4)
                ultimoDia = int.Parse(Meses.Abril);
            if (mes == 5)
                ultimoDia = int.Parse(Meses.Maio);
            if (mes == 6)
                ultimoDia = int.Parse(Meses.Junho);
            if (mes == 7)
                ultimoDia = int.Parse(Meses.Julho);
            if (mes == 8)
                ultimoDia = int.Parse(Meses.Agosto);
            if (mes == 9)
                ultimoDia = int.Parse(Meses.Setembro);
            if (mes == 10)
                ultimoDia = int.Parse(Meses.Outubro);
            if (mes == 11)
                ultimoDia = int.Parse(Meses.Novembro);
            if (mes == 12)
                ultimoDia = int.Parse(Meses.Dezembro);

            return ultimoDia;
        }
    }
}
