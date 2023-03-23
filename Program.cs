﻿using System.Collections.Generic;
int numero;
Console.WriteLine("1. Ingrese los importes de un curso");
Console.WriteLine("2. Ver las estadisticas");
Console.WriteLine("3. Salir");
numero = ingresarNumero("Ingrese un numero");
int ingresarNumero(string msj)
{
 int num;
 Console.WriteLine(msj);
 num = int.Parse(Console.ReadLine());
 while(num != 1 && num != 2 && num != 3)
 {
  Console.WriteLine("Ingresaste mal los datos, volve a hacerlo");
  Console.WriteLine(msj);
  num = int.Parse(Console.ReadLine());
 }
return num;
}
int acum = 0, numAlumnos = 0, importe = 0;
Dictionary<string, int> dicAlumnos = new Dictionary<string, int>();
while(numero != 3)
{
 string nombreCurso = "";
switch (numero)
{
    case 1:
    nombreCurso = ingresarCurso();
     while(dicAlumnos.ContainsKey(nombreCurso))
    {
      Console.WriteLine("Ese nombre de curso ya existe");
       nombreCurso = ingresarCurso();
    }
    numAlumnos = ingresarAlumnos();
    importe = ingresarDinero(numAlumnos);
    acum += importe;
    dicAlumnos.Add(nombreCurso, importe);
    break;

    case 2:
    calcularYMostrarMayorPlata(dicAlumnos);
    calcularYMostrarPromedio(acum, dicAlumnos);
    mostrarPlataAcumulada(acum);
    mostrarCantidadDeCursosParticipantes(dicAlumnos);
    break;
}
numero = ingresarNumero("Ingrese un numero");
}
int ingresarAlumnos()
{
 int num;
 Console.WriteLine("Ingrese la cantidad de estudiantes del curso");
 num = int.Parse(Console.ReadLine());
 while(num < 0)
 {
   Console.WriteLine("Ingresaste mal los datos, volve a hacerlo");
   Console.WriteLine("Ingrese la cantidad de estudiantes del curso");
   num = int.Parse(Console.ReadLine());
 }
 return num;
}
string ingresarCurso()
{
 string nombre;
 Console.WriteLine("Ingrese el nombre del curso");
 nombre = Console.ReadLine();
 return nombre;
}
int ingresarDinero(int numAlumnos)
{
 int dinero, dineroTotal = 0;
 for (int i = 0; i < numAlumnos; i++)
 {
    Console.WriteLine("Ingrese la cantidad de dinero que va a regalar el estudiante: " + (i + 1));
    dinero = int.Parse(Console.ReadLine());
    dineroTotal += dinero;
 }
 return dineroTotal;
}
void calcularYMostrarMayorPlata(Dictionary<string, int> dicAlumnos)
{
 int valorMax = 0;
 string cursoMax = "";
 foreach (string curso in dicAlumnos.Keys)
 {
    if(valorMax < dicAlumnos[curso])
    {
      valorMax = dicAlumnos[curso];
      cursoMax = curso;
    }
 }
 Console.WriteLine("El curso con mayor plata regalada es: " + cursoMax + " con: $" + valorMax);
}
void calcularYMostrarPromedio(int acum, Dictionary<string, int> dicAlumnos)
{
int promedio; 
promedio = acum / dicAlumnos.Count;
Console.WriteLine("El promedio de plata regalada por todos los cursos es: $" + promedio);
}
void mostrarPlataAcumulada(int acum)
{
 Console.WriteLine("La plata recaudada entre todos los cursos es: $" + acum);
}
void mostrarCantidadDeCursosParticipantes(Dictionary<string, int> dicAlumnos)
{
 Console.WriteLine("La cantidad de cursos participantes es: " + dicAlumnos.Count);
}
