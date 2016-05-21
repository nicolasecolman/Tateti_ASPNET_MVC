using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace TP2.Models
{
    public class Estadisticas
    {
        public String Name;
        public int Ganados;
        public int Perdidos;
        public int Empatados;


        public void setEstadisticas(string ganador)
        {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            String strFullPath = path + "/Estadisticas.TXT";
            String strFullPathAux = path + "/texto_new.txt";
            TextReader txtReader = File.OpenText(strFullPath);
            TextWriter txtWriter = File.CreateText(strFullPathAux);
            while (true)
            {
                string newLine = string.Empty;
                string line = txtReader.ReadLine();
                if (line != null)
                {
                    string[] valores = line.Split(';');
                    
                    string _strGanados = valores[1];
                    int _Ganados = int.MinValue;
                    int.TryParse(_strGanados, out _Ganados);

                    string _strPerdidos = valores[2];
                    int _Perdidos = int.MinValue;
                    int.TryParse(_strPerdidos, out _Perdidos);

                    string _strEmpatados = valores[3];
                    int _Empatados = int.MinValue;
                    int.TryParse(_strEmpatados, out _Empatados);
                    
                    //En caso de empate
                    if (ganador.StartsWith("0"))
                    {
                        _Empatados = _Empatados + 1;
                        line = valores[0] + ";" + _Ganados.ToString() + ";" + _Perdidos.ToString() + ";" + _Empatados.ToString() + ";";                        
                    }
                    else
                    {
                        //Hay un ganador
                        if (line.StartsWith(ganador))
                        {
                            _Ganados = _Ganados + 1;
                            line = ganador + ";" + _Ganados.ToString() + ";" + _Perdidos.ToString() + ";" + _Empatados.ToString() + ";";
                        }
                        else
                        {
                            _Perdidos = _Perdidos + 1;
                            line = valores[0] + ";" + _Ganados.ToString() + ";" + _Perdidos.ToString() + ";" + _Empatados.ToString() + ";";
                        }

                    }

                    txtWriter.WriteLine(line);
                }
                else { break; }
            }

            txtReader.Close();
            txtWriter.Close();
            File.Delete(strFullPath);
            File.Copy(strFullPathAux, strFullPath);
            File.Delete(strFullPathAux);
        }


        //Abre el archivo de texto, lo recorre y devuelve una estructura
        public List<Estadisticas> getEstadisticas()
        {
            //Declaro objeto que voy a retornar
            var objEstadisticas = new List<Estadisticas> { };
            //Abro archivo
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();                       
            StreamReader reader = File.OpenText(path + "/Estadisticas.TXT");

            //Recorro archivo
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                string[] valores = currentLine.Split(';');
                String _Jugador = valores[0];

                string _strGanados = valores[1];
                int _Ganados = int.MinValue;
                int.TryParse(_strGanados, out _Ganados);

                string _strPerdidos = valores[2];
                int _Perdidos = int.MinValue;
                int.TryParse(_strPerdidos, out _Perdidos);
                
                string _strEmpatados = valores[3];
                int _Empatados = int.MinValue;
                int.TryParse(_strEmpatados, out _Empatados);
                
                objEstadisticas.Add(new Estadisticas { Name = _Jugador, 
                                                       Ganados = _Ganados,
                                                       Perdidos = _Perdidos,
                                                       Empatados = _Empatados
                                                     }
                                   );
            }

            reader.Close();

            return objEstadisticas;
        }

        public void restartEstadisticas() {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            String strFullPath = path + "/Estadisticas.TXT";
            String strFullPathAux = path + "/texto_new.txt";
            TextReader txtReader = File.OpenText(strFullPath);
            TextWriter txtWriter = File.CreateText(strFullPathAux);
            while (true)
            {
                string newLine = string.Empty;
                string line = txtReader.ReadLine();
                if (line != null)
                {
                    string[] valores = line.Split(';');
                                        
                    int _Ganados = 0;
                    
                    int _Perdidos = 0;
                    
                    int _Empatados = 0;
                    
                    line = valores[0] + ";" + _Ganados.ToString() + ";" + _Perdidos.ToString() + ";" + _Empatados.ToString() + ";";
                    
                    txtWriter.WriteLine(line);
                }
                else { break; }
            }

            txtReader.Close();
            txtWriter.Close();
            File.Delete(strFullPath);
            File.Copy(strFullPathAux, strFullPath);
            File.Delete(strFullPathAux);
        }

    }
}