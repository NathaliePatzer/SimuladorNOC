using System.Net.Mail;

namespace SimuladorDeMensagens;
internal class Nodo
{
    public int Posicao;
    public Nodo NodoEsquerda;
    public Nodo NodoDireita;

    public void ReceberMensagem(Mensagem SMS)
    {
        int posicaoNodoReceber = SMS.caminho == "proximo" ? NodoEsquerda.Posicao : NodoDireita.Posicao;
        int posicaoNodoEnviar = SMS.caminho == "proximo" ? NodoDireita.Posicao : NodoEsquerda.Posicao;
        Nodo nodoEnviar = SMS.caminho == "proximo" ? NodoDireita : NodoEsquerda;

            Console.WriteLine("Proc[" + Posicao + "] recebeu a mensagem de Proc[" + posicaoNodoReceber + "]");
            Thread.Sleep(800);
            if (Posicao == SMS.Destino)
            {
                Console.WriteLine("Proc[" + Posicao + "] é o destino \nProc[" + Posicao + "] consumiu a mensagem");
            }
            else
            {
                //Console.WriteLine("A mensagem não é para este nó...");
                Thread.Sleep(800);
                Console.WriteLine("Proc[" + Posicao + "]enviou a mensagem para o Proc[" + posicaoNodoEnviar + "]");
                Thread.Sleep(800);
                nodoEnviar.ReceberMensagem(SMS);
            }
    }

    public void CalcularCaminho (EncontrarCaminho encontrarCaminho)
    {
        encontrarCaminho.distancia++;

        if(Posicao == encontrarCaminho.destino)
        {
            return;
        }

        if (encontrarCaminho.direcao == "proximo")
        {
            NodoDireita.CalcularCaminho(encontrarCaminho);
        } else
        {
            NodoEsquerda.CalcularCaminho(encontrarCaminho);
        }
        
    }
}
