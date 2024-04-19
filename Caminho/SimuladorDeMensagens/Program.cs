using SimuladorDeMensagens;

internal class Program
{
    static Nodo primeiroNodo;
    static int numeroNodos;
    static Nodo[] nodosArray;
    private static void Main(string[] args)
    {
        Console.Write("Digite o número de nodos do anel: ");
        string valor = Console.ReadLine()!;
        numeroNodos = int.Parse(valor);
        nodosArray = new Nodo[numeroNodos];

        //cria o anel de nós
        primeiroNodo = new Nodo();
        primeiroNodo.Posicao = 0;
        primeiroNodo.NodoDireita = CriarNodoAnel(primeiroNodo, 0);

        //cria a mensagem 
        Mensagem sms = new Mensagem();
        Console.Write("Digite o nó de origem da mensagem: ");
        sms.Origem = int.Parse(Console.ReadLine()!);
        Console.Write("Digite o nó de destino da mensagem: ");
        sms.Destino = int.Parse(Console.ReadLine()!);
        Console.Write("Digite a mensagem: ");
        sms.Texto = Console.ReadLine()!;

        //cria a classe EncontrarCaminho para percorrer a direita
        EncontrarCaminho caminhoDireita = new EncontrarCaminho();
        caminhoDireita.direcao = "proximo";
        caminhoDireita.destino = sms.Destino;
        nodosArray[sms.Origem].CalcularCaminho(caminhoDireita);
        Console.WriteLine($"Distância percorrendo a direita: {caminhoDireita.distancia}");

        //cria a classe EncontrarCaminho para percorrer a esquerda
        EncontrarCaminho caminhoEsquerda = new EncontrarCaminho();
        caminhoEsquerda.direcao = "anterior";
        caminhoEsquerda.destino = sms.Destino;
        nodosArray[sms.Origem].CalcularCaminho(caminhoEsquerda);
        Console.WriteLine($"Distância percorrendo a esquerda: {caminhoEsquerda.distancia}");

        //compara as distancias
        sms.caminho = caminhoDireita.distancia < caminhoEsquerda.distancia ?  caminhoDireita.direcao : caminhoEsquerda.direcao;

        //enviar a mensagem
        int enviarNodo = caminhoDireita.distancia < caminhoEsquerda.distancia ? sms.Origem+1 : sms.Origem-1;
        Console.WriteLine("Proc[" + sms.Origem + "] criou a mensagem");
        Thread.Sleep(800);
        Console.WriteLine("Proc[" + sms.Origem + "] enviou a mensagem para o Proc[" + (enviarNodo) + "]");
        Thread.Sleep(800);
        nodosArray[enviarNodo].ReceberMensagem(sms);
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
        nodosArray[posicao] = nodo;
        return nodo;
    }
}