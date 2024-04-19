using System.Net.Mail;
using System.Numerics;

namespace SimuladorDeMensagens;
internal class Nodo
{
    public Vector2 Posicao;
    public Nodo[] vizinhos = new Nodo[4];

    public void EnviarMensagemVizinhos(Mensagem sms)
    {     
        float distanciaThisDestino = (Vector2.Distance(sms.Destino, this.Posicao));

        foreach (var n in vizinhos)
        {          
            if (n == null && !sms.entregue) continue;

            float distanciaNDestino = (Vector2.Distance(sms.Destino, n.Posicao));

            if (distanciaNDestino < distanciaThisDestino && !sms.entregue)
            {             
                Console.WriteLine($"Enviando mensagem de Proc[{this.Posicao}] para Proc[{n.Posicao}]");
                n.ReceberMensagem(sms, this);
            }              
        }
    }
    
    public void ReceberMensagem(Mensagem sms, Nodo enviador)
    {
        Console.WriteLine($"Proc[{Posicao}] recebeu a mensagem de Proc[{enviador.Posicao}]");

        if (Posicao == sms.Destino)
        {
            Console.WriteLine($"Proc[{Posicao}] é o destino \nProc[{Posicao}] consumiu a mensagem");
            sms.entregue = true;
        } else if(!sms.entregue)
        {
            this.EnviarMensagemVizinhos(sms);
        }
    }
}
