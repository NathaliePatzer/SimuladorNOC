using SimuladorDeMensagens;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;

internal class Program
{
    static Nodo primeiroNodo;
    static int numeroNodos;
    static Dictionary<Vector2, Nodo> mapaMesh;
    private static void Main(string[] args)
    {
        Console.Write("Digite o número de nodos do anel: ");
        string valor = Console.ReadLine()!;
        numeroNodos = int.Parse(valor);

        //cria o anel de nós
        mapaMesh = new Dictionary<Vector2, Nodo>();
        primeiroNodo = new Nodo();
        primeiroNodo.Posicao = new Vector2(0,0); 
        mapaMesh.Add(primeiroNodo.Posicao, primeiroNodo);
        CriarNodoAnel(new Vector2(1, 0));
        CriarNodoAnel(new Vector2(0, 1));

        foreach (var nodo in mapaMesh.Values)
        {
            Vector2 posicaoPraChecar1;
            posicaoPraChecar1.X = nodo.Posicao.X - 1;
            posicaoPraChecar1.Y = nodo.Posicao.Y;
            if (mapaMesh.ContainsKey(posicaoPraChecar1))
            {
                nodo.vizinhos[0] = mapaMesh[posicaoPraChecar1];
            }

            Vector2 posicaoPraChecar2;
            posicaoPraChecar2.X = nodo.Posicao.X + 1;
            posicaoPraChecar2.Y = nodo.Posicao.Y;
            if (mapaMesh.ContainsKey(posicaoPraChecar2))
            {
                nodo.vizinhos[1] = mapaMesh[posicaoPraChecar2];
            }

            Vector2 posicaoPraChecar3;
            posicaoPraChecar3.X = nodo.Posicao.X;
            posicaoPraChecar3.Y = nodo.Posicao.Y-1;
            if (mapaMesh.ContainsKey(posicaoPraChecar3))
            {
                nodo.vizinhos[2] = mapaMesh[posicaoPraChecar3];
            }

            Vector2 posicaoPraChecar4;
            posicaoPraChecar4.X = nodo.Posicao.X;
            posicaoPraChecar4.Y = nodo.Posicao.Y + 1;
            if (mapaMesh.ContainsKey(posicaoPraChecar4))
            {
                nodo.vizinhos[3] = mapaMesh[posicaoPraChecar4];
            }
        }

        CriarSMS();
    }

    public static void CriarNodoAnel (Vector2 posicao)
    {
        if (posicao.X >= numeroNodos || posicao.Y >= numeroNodos || mapaMesh.ContainsKey(posicao))
        {     
            return;
        }
        
        Nodo nodo = new Nodo();
        nodo.Posicao = posicao;      
        
        mapaMesh.Add(posicao, nodo);    

        CriarNodoAnel(new Vector2(posicao.X+1, posicao.Y));
        CriarNodoAnel(new Vector2(posicao.X, posicao.Y+1));
        return;        
    }

    public static void CriarSMS()
    {
        Mensagem sms = new Mensagem();
        Console.Write("Digite X do nó de origem da mensagem: ");
        sms.Origem.X = int.Parse(Console.ReadLine()!);
        Console.Write("Digite Y do nó de origem da mensagem: ");
        sms.Origem.Y = int.Parse(Console.ReadLine()!);
        Console.Write("Digite X do nó de destino da mensagem: ");
        sms.Destino.X = int.Parse(Console.ReadLine()!);
        Console.Write("Digite Y do nó de destino da mensagem: ");
        sms.Destino.Y = int.Parse(Console.ReadLine()!);
        Console.Write("Digite a mensagem: ");
        sms.Texto = Console.ReadLine()!;
        //sms.entregue = false;
        Console.WriteLine($"Proc[{sms.Origem}] criou a mensagem");
        mapaMesh[sms.Origem].EnviarMensagemVizinhos(sms);
    }
    
}