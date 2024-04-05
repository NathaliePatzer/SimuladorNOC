using SimuladorDeMensagens;

internal class Program
{
    static Nodo primeiroNodo;
    static int numeroNodos;
    private static void Main(string[] args)
    {
        Console.Write("Digite o número de nodos do anel: ");
        string valor = Console.ReadLine()!;
        numeroNodos = int.Parse(valor);

        //cria o anel de nós
        primeiroNodo = new Nodo();
        primeiroNodo.Posicao = 0;
        primeiroNodo.NodoDireita = CriarNodoAnel(primeiroNodo, 0);

        //cria a mensagem e passa para o primeiro nó 
        Mensagem sms = new Mensagem();
        Console.Write("Digite o nó de origem da mensagem: ");
        sms.Origem = int.Parse(Console.ReadLine()!);
        Console.Write("Digite o nó de destino da mensagem: ");
        sms.Destino = int.Parse(Console.ReadLine()!);
        Console.Write("Digite a mensagem: ");
        sms.Texto = Console.ReadLine()!;
        primeiroNodo.ReceberMensagem(sms);
    }

    public static Nodo CriarNodoAnel (Nodo nodoAnterior, int posicao)
    {
        posicao++;

        if (posicao >= numeroNodos)
        {
            primeiroNodo.NodoEsquerda = nodoAnterior;
            return primeiroNodo;
        }
        
        Nodo nodo = new Nodo();
        nodo.Posicao = posicao;
        nodo.NodoEsquerda = nodoAnterior;   
        nodo.NodoDireita = CriarNodoAnel(nodo, posicao);
        return nodo;
    }
}