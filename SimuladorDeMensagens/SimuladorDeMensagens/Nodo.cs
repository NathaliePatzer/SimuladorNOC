namespace SimuladorDeMensagens;
internal class Nodo
{
    public int Posicao;
    public Nodo NodoEsquerda;
    public Nodo NodoDireita;

    public void ReceberMensagem(Mensagem SMS)
    {
        Console.WriteLine("O nó " + Posicao + " recebeu a mensagem.");
        Thread.Sleep(1000);
        if (Posicao == SMS.Destino)
        {
            Console.WriteLine("Destino alcançado!");
        } else
        {
            Console.WriteLine("A mensagem não é para este nó...");
            Thread.Sleep(800);
            Console.WriteLine("Mandando mensagem para o nó " + NodoDireita.Posicao);
            Thread.Sleep(1000);
            NodoDireita.ReceberMensagem(SMS);
        }
    }
}
