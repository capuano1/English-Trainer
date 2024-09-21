using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
  static Dictionary<string, string> presSimple = File.ReadAllLines("presSimpleVerbs.txt").Select(x => x.Split(' ')).ToDictionary(x => x[0], x => x[1]);
  static Dictionary<string, string> pronouns = new Dictionary<string, string>(){
    {"Eu", "I"},
    {"Você", "You"},
    {"Ele", "He"},
    {"Ela", "She"},
    {"Isto", "It"},
    {"Nós", "We"},
    {"Eles/Elas", "They"}
  };

  public static void Main (string[] args) {
    while (true) {
      Console.WriteLine("Selecione um modo:");
      Console.WriteLine("1 - Simple Present com verbo em inglês");
      Console.WriteLine("2 - Simple Present com verbo em português");
      int ans = Int32.Parse(Console.ReadLine());
      switch(ans) {
        case 1:
          SimplePresent1();
          break;
        case 2:
          SimplePresent2();
          break;
        default:
          Console.WriteLine("Digite uma opção válida!");
          break;
      }
    }
  }

  public static string doSimplePresent(string verb) {
    verb = verb.ToLower();
    if (verb == "have") return "has";
    char last = verb[verb.Length-1];
    char penult = verb[verb.Length-2];
    if (last == 'o' || last == 'z' || last == 'x' || (penult == 's' && last == 's') || (penult == 's' && last == 'h') || (penult == 'c' && last == 'h')) {
      verb = string.Concat(verb, "es");
      return verb;
    }
    else if (last == 'y' && (penult != 'a' && penult != 'e' && penult != 'i' && penult != 'o' && penult != 'u')) {
      verb = verb.TrimEnd(last);
      verb = string.Concat(verb, "ies");
      return verb;
    }
    else {
      return string.Concat(verb, 's');
    }
  }
  
  public static void SimplePresent1() {
    Random rnd1 = new Random();
    Random rnd2 = new Random();
    Console.WriteLine("Vou te mostrar um pronome em português e um verbo em inglês no infinitivo");
    Console.WriteLine("O seu trabalho é escrever como ficaria em inglês");
    Console.WriteLine("Exemplo:");
    Console.WriteLine("Se eu disser: \"Ele + talk\"");
    Console.WriteLine("Você deve responder: \"He talks\"\n\n");
    while (true) {
      int rand1 = rnd1.Next(7), rand2 = rnd2.Next(presSimple.Count());
      string pron = pronouns.ElementAt(rand1).Key;
      string verb = presSimple.ElementAt(rand2).Key;
      Console.WriteLine("{0} + {1}", pron, verb);
      if (rand1 == 2 || rand1 == 3 || rand1 == 4) {
        verb = doSimplePresent(verb);
      }
      string ans = string.Concat(string.Concat(pronouns.ElementAt(rand1).Value, ' '), verb).ToLower();
      string player = Console.ReadLine();
      player = player.ToLower();
      if (player == ans) {
        Console.WriteLine("Correct!\n");
        continue;
      }
      else {
        Console.WriteLine("Wrong!");
        Console.WriteLine("Correct answer: {0}{1}\n", char.ToUpper(ans[0]), ans.Substring(1));
        continue;
      }
    }
  }

  public static void SimplePresent2() {
    Random rnd1 = new Random();
    Random rnd2 = new Random();
    Console.WriteLine("Vou te mostrar um pronome e um verbo no infinitivo em português");
    Console.WriteLine("O seu trabalho é escrever como ficaria em inglês");
    Console.WriteLine("Exemplo:");
    Console.WriteLine("Se eu disser: \"Ele + falar\"");
    Console.WriteLine("Você deve responder: \"He talks\"\n\n");
    while (true) {
      int rand1 = rnd1.Next(7), rand2 = rnd2.Next(presSimple.Count());
      string pron = pronouns.ElementAt(rand1).Key;
      string verb = presSimple.ElementAt(rand2).Key;
      Console.WriteLine("{0} + {1}", pron, presSimple.ElementAt(rand2).Value);
      if (rand1 == 2 || rand1 == 3 || rand1 == 4) {
        verb = doSimplePresent(verb);
      }
      string ans = string.Concat(string.Concat(pronouns.ElementAt(rand1).Value, ' '), verb).ToLower();
      string player = Console.ReadLine();
      player = player.ToLower();
      if (player == ans) {
        Console.WriteLine("Correct!\n");
        continue;
      }
      else {
        Console.WriteLine("Wrong!");
        Console.WriteLine("Correct answer: {0}{1}\n", char.ToUpper(ans[0]), ans.Substring(1));
        continue;
      }
    }
  }

  
}