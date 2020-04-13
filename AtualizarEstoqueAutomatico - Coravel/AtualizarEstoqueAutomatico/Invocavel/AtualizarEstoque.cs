using System;
using System.Threading.Tasks;
using Coravel.Invocable;

namespace AtualizarEstoqueAutomatico.Invocavel
{
    public class AtualizarEstoque : IInvocable
    {
        public Task Invoke()
        {
            //var dataAtual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("America/Fortaleza"));
            var dataAtual = DateTime.Now;
            Console.WriteLine($"Testar execução | Horario : {dataAtual}");

            return Task.CompletedTask;
        }
    }
}
